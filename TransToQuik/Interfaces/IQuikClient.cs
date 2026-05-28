using System;
using System.Threading;
using System.Threading.Tasks;
using TransToQuik.Enums;
using TransToQuik.Interop;
using TransToQuik.Models;
using TransToQuik.Models.Transactions;

namespace TransToQuik.Interfaces;

public interface IQuikClient : IDisposable
{
    IQuikConnection Connection { get; }
    IQuikInfoApi InfoApi { get; }
    QuikResult<ConnectError> Connect(string path);
    QuikTransactionResult SendTransaction(QuikTransaction transaction);
    Task<QuikAsyncTransactionResult> SendTransactionAsync(QuikTransaction transaction, CancellationToken cancellationToken = default);
    void StartOrders(IQuikHandler<QuikOrder> handler);
    void StartTrades(IQuikHandler<QuikTrade> handler);
    void StartOrders(OrderStatusCallback funcOrderStatusCallback);
    void StartTrades(TradeStatusCallback funcTradesStatusCallback);
    QuikResult<SubscribeError> SubscribeOrders(Action<SubscriptionBuilder> configure);
    QuikResult<SubscribeError> SubscribeTrades(Action<SubscriptionBuilder> configure);
    QuikResult<SubscribeError> SubscribeOrders(string classCodes, string secCodes);
    QuikResult<SubscribeError> SubscribeTrades(string classCodes, string secCodes);
    QuikResult<SubscribeError> UnsubscribeOrders();
    QuikResult<SubscribeError> UnsubscribeTrades();
}
