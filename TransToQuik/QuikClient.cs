using TransToQuik.Enums;
using TransToQuik.Exceptions;
using TransToQuik.Interfaces;
using TransToQuik.Interop;
using TransToQuik.Mappers;
using TransToQuik.Models;
using TransToQuik.Models.Transactions;

namespace TransToQuik;

public class QuikClient : IQuikClient
{
    private static void ThrowIfNotConnected(bool connected)
    {
        if (!connected)
        {
            throw new TransactionException("Cannot send transaction. Not connected to QUIK.");
        }
    }

    private static void ThrowIfInvalid(ValidationResult validation)
    {
        if (!validation.IsValid)
        {
            throw new TransactionException(validation.ErrorMessage);
        }
    }

    private static QuikResult<SubscribeError> CreateSubscriptionResult(int code) =>
        QuikResultFactory.From(
            code,
            default,
            string.Empty,
            SubscribeMapper.Instance);

    private readonly IQuikConnection _connection;
    private readonly IQuikManagerApi _managerApi;
    private readonly uint _maxMessageSize = QuikConstants.MaxMessageSize;
    private TransactionReplyCallback _callback;
    private TradeCallbackAdapter _tradeCallbackAdapter;
    private OrderCallbackAdapter _orderCallbackAdapter;

    public IQuikConnection Connection => _connection;
    public IQuikInfoApi InfoApi { get; }

    public QuikClient(
        IQuikConnection connection,
        IQuikManagerApi managerApi,
        QuikInfoApi infoApi)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _managerApi = managerApi ?? throw new ArgumentNullException(nameof(managerApi));
        InfoApi = infoApi ?? throw new ArgumentNullException(nameof(infoApi));
    }

    public void Dispose() => _connection.Dispose();

    public QuikResult<ConnectError> Connect(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        return _connection.Connect(path);
    }

    public QuikTransactionResult SendTransaction(QuikTransaction transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);
        ThrowIfInvalid(transaction.Validate());
        return SendSyncTransaction(transaction.ToQuikString());
    }

    public async Task<QuikAsyncTransactionResult> SendTransactionAsync(
        QuikTransaction transaction,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(transaction);
        ThrowIfInvalid(transaction.Validate());

        if (_callback is null || _callback != CallbackDispatcher.TransactionReplyCallback)
        {
            _callback = CallbackDispatcher.TransactionReplyCallback;
            var callbackResult = SetTransactionsReplyCallback(_callback);
            if (!callbackResult.Success)
            {
                throw new TransactionException($"Failed to set transaction reply callback: {callbackResult.ErrorKind}");
            }
        }

        cancellationToken.ThrowIfCancellationRequested();

        var transId = transaction.TransId;
        if (!CallbackDispatcher.TryRegisterWaiter(transId, cancellationToken, out var waiter))
        {
            throw new TransactionException($"TRANS_ID={transId} is already waiting for a reply.");
        }

        try
        {
            var result = SendAsyncTransaction(transaction);
            if (!result.Success)
            {
                CallbackDispatcher.RemoveWaiter(transId);
                throw new TransactionException($"Failed to send async transaction: {result.ErrorKind}. {result.Message}");
            }

            return await waiter.ConfigureAwait(false);
        }
        catch
        {
            CallbackDispatcher.RemoveWaiter(transId);
            throw;
        }
    }

    public QuikResult<SubscribeError> SubscribeOrders(Action<SubscriptionBuilder> configure)
    {
        var builder = new SubscriptionBuilder();
        configure?.Invoke(builder);
        return SubscribeByEntries(builder.Build().Entries, _managerApi.SubscribeOrders);
    }

    public QuikResult<SubscribeError> SubscribeTrades(Action<SubscriptionBuilder> configure)
    {
        var builder = new SubscriptionBuilder();
        configure?.Invoke(builder);
        return SubscribeByEntries(builder.Build().Entries, _managerApi.SubscribeTrades);
    }

    public QuikResult<SubscribeError> SubscribeOrders(string classCodes, string secCodes) =>
        CreateSubscriptionResult(ExecuteOnOpenConnection(() => _managerApi.SubscribeOrders(classCodes, secCodes)));

    public QuikResult<SubscribeError> SubscribeTrades(string classCodes, string secCodes) =>
        CreateSubscriptionResult(ExecuteOnOpenConnection(() => _managerApi.SubscribeTrades(classCodes, secCodes)));

    private QuikResult<SubscribeError> SubscribeByEntries(
        IReadOnlyList<SubscriptionEntry> entries,
        Func<string, string, int> subscribe)
    {
        if (entries.Count == 0)
        {
            return CreateSubscriptionResult((int)QuikReturnStatus.Success);
        }

        var last = CreateSubscriptionResult((int)QuikReturnStatus.Success);
        foreach (var entry in entries)
        {
            last = CreateSubscriptionResult(ExecuteOnOpenConnection(() => subscribe(entry.ClassCode, entry.SecCodes)));
            if (!last.Success)
            {
                return last;
            }
        }

        return last;
    }

    public void StartOrders(IQuikHandler<QuikOrder> handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        _orderCallbackAdapter = new OrderCallbackAdapter(handler);
        StartOrders(_orderCallbackAdapter.OrderCallback);
    }

    public void StartTrades(IQuikHandler<QuikTrade> handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        _tradeCallbackAdapter = new TradeCallbackAdapter(handler);
        StartTrades(_tradeCallbackAdapter.TradeCallback);
    }

    public void StartOrders(OrderStatusCallback funcOrderStatusCallback) =>
        ExecuteOnOpenConnection(() => _managerApi.StartOrders(funcOrderStatusCallback));

    public void StartTrades(TradeStatusCallback funcTradesStatusCallback) =>
        ExecuteOnOpenConnection(() => _managerApi.StartTrades(funcTradesStatusCallback));

    public QuikResult<SubscribeError> UnsubscribeOrders()
    {
        _orderCallbackAdapter = null;
        return CreateSubscriptionResult(ExecuteOnOpenConnection(_managerApi.UnsubscribeOrders));
    }

    public QuikResult<SubscribeError> UnsubscribeTrades()
    {
        _tradeCallbackAdapter = null;
        return CreateSubscriptionResult(ExecuteOnOpenConnection(_managerApi.UnsubscribeTrades));
    }

    private QuikResult<SimpleError> SetTransactionsReplyCallback(TransactionReplyCallback replyCallback)
    {
        ArgumentNullException.ThrowIfNull(replyCallback);

        _callback = replyCallback;

        return ExecuteOnOpenConnection(() =>
        {
            var errorMessage = new NativeBuffer(_maxMessageSize);
            return QuikResultFactory.From(
                _managerApi.SetTransactionsReplyCallback(_callback, out var extendedErrorCode, errorMessage.Bytes, _maxMessageSize),
                extendedErrorCode,
                errorMessage.AsString(),
                SimpleMapper.Instance);
        });
    }

    private QuikTransactionResult SendSyncTransaction(string serializedTransaction)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(serializedTransaction);

        return ExecuteOnOpenConnection(() =>
        {
            var resultMessage = new NativeBuffer(_maxMessageSize);
            var errorMessage = new NativeBuffer(_maxMessageSize);
            var code = _managerApi.SendSyncTransaction(
                serializedTransaction,
                out var replyCode,
                out var transId,
                out var orderNum,
                resultMessage.Bytes,
                _maxMessageSize,
                out var extendedErrorCode,
                errorMessage.Bytes,
                _maxMessageSize);

            return QuikTransactionResultFactory.From(
                code,
                extendedErrorCode,
                errorMessage.AsString(),
                replyCode,
                transId,
                orderNum,
                resultMessage.AsString());
        });
    }

    private QuikResult<TransactionError> SendAsyncTransaction(QuikTransaction transaction) =>
        SendAsyncTransaction(transaction.ToQuikString());

    private QuikResult<TransactionError> SendAsyncTransaction(string serializedTransaction)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(serializedTransaction);

        if (_callback is null)
        {
            throw new TransactionException("Cannot send async transaction: callback is not set.");
        }

        return ExecuteOnOpenConnection(() =>
        {
            var errorMessage = new NativeBuffer(_maxMessageSize);
            var code = _managerApi.SendAsyncTransaction(serializedTransaction, out var extendedErrorCode, errorMessage.Bytes, _maxMessageSize);

            return QuikResultFactory.From(
                code,
                extendedErrorCode,
                errorMessage.AsString(),
                TransactionMapper.Instance);
        });
    }

    private void ExecuteOnOpenConnection(Action func)
    {
        ArgumentNullException.ThrowIfNull(func);
        ThrowIfNotConnected(_connection.Connected);
        func.Invoke();
    }

    private T ExecuteOnOpenConnection<T>(Func<T> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        ThrowIfNotConnected(_connection.Connected);
        return func.Invoke();
    }
}
