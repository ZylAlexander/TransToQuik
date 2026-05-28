using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TransToQuik.Models;

namespace TransToQuik;

internal static class CallbackDispatcher
{
    public static event Action<string> UnexpectedReply;

    private static readonly ConcurrentDictionary<long, TaskCompletionSource<QuikAsyncTransactionResult>> _waiters = new();

    /// <summary>
    /// Регистрирует ожидание ответа по TRANS_ID. Возвращает false, если для этого ID ожидание уже открыто.
    /// </summary>
    public static bool TryRegisterWaiter(
        long transactionId,
        CancellationToken cancellationToken,
        out Task<QuikAsyncTransactionResult> task)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var taskCompletionSource = new TaskCompletionSource<QuikAsyncTransactionResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        if (!_waiters.TryAdd(transactionId, taskCompletionSource))
        {
            task = null;
            return false;
        }

        if (cancellationToken.CanBeCanceled)
        {
            cancellationToken.Register(() =>
            {
                if (_waiters.TryRemove(transactionId, out var removedTcs))
                {
                    removedTcs.TrySetCanceled(cancellationToken);
                }
            });
        }

        task = taskCompletionSource.Task;
        return true;
    }

    public static void RemoveWaiter(long transactionId)
    {
        _waiters.TryRemove(transactionId, out _);
    }

    public static void TransactionReplyCallback(
        int result,
        int extendedErrorCode,
        int replyCode,
        uint transId,
        ulong orderNum,
        string resultMessage,
        IntPtr replyDescriptor)
    {
        if (!_waiters.TryRemove(transId, out var tcs))
        {
            UnexpectedReply?.Invoke($"Unexpected reply for transaction {transId}");
            return;
        }

        var transactionResult = QuikTransactionResultFactory.From(
            result,
            extendedErrorCode,
            string.Empty,
            replyCode,
            transId,
            orderNum,
            resultMessage);

        var reply = TransactionReplySnapshotFactory.Capture(QuikNativeWrapper.DefaultInstance, replyDescriptor);
        tcs.TrySetResult(new QuikAsyncTransactionResult(transactionResult, reply));
    }
}
