using System;
using System.Runtime.InteropServices;

namespace TransToQuik.Interop;

public delegate void TransactionReplyCallback(
    int result,
    int extendedErrorCode,
    int replyCode,
    uint transId,
    ulong orderNum,
    [MarshalAs(UnmanagedType.LPStr)] string resultMessage,
    IntPtr replyDescriptor);

public delegate void OrderStatusCallback(
    int mode,
    uint transId,
    ulong number,
    [MarshalAs(UnmanagedType.LPStr)] string classCode,
    [MarshalAs(UnmanagedType.LPStr)] string secCode,
    double price,
    long balance,
    double value,
    int isSell,
    int status,
    IntPtr orderDescriptor);

public delegate void TradeStatusCallback(
    int mode,
    ulong number,
    ulong orderNum,
    [MarshalAs(UnmanagedType.LPStr)] string classCode,
    [MarshalAs(UnmanagedType.LPStr)] string secCode,
    double price,
    long qty,
    double value,
    int isSell,
    IntPtr tradeDescriptor);

internal static partial class QuikNativeApi
{
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_SEND_SYNC_TRANSACTION")]
    public static partial int SendSyncTransaction(
        [MarshalAs(UnmanagedType.LPStr)] string serializedTransaction,
        out int replyCode,
        out uint transId,
        out ulong orderNum,
        byte[] resultMessage,
        uint resultMessageSize,
        out int extendedErrorCode,
        byte[] errorMessage,
        uint errorMessageSize);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_SEND_ASYNC_TRANSACTION")]
    public static partial int SendAsyncTransaction(
        [MarshalAs(UnmanagedType.LPStr)] string serializedTransaction,
        out int errorCode,
        byte[] errorMessage,
        uint errorMessageSize);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_SET_TRANSACTIONS_REPLY_CALLBACK")]
    public static partial int SetTransactionsReplyCallback(
        TransactionReplyCallback transactionReplyCallback,
        out int extendedErrorCode,
        byte[] errorMessage,
        uint errorMessageSize);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_SUBSCRIBE_ORDERS")]
    public static partial int SubscribeOrders(
        [MarshalAs(UnmanagedType.LPStr)] string classCode,
        [MarshalAs(UnmanagedType.LPStr)] string secCodes);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_SUBSCRIBE_TRADES")]
    public static partial int SubscribeTrades(
        [MarshalAs(UnmanagedType.LPStr)] string classCode,
        [MarshalAs(UnmanagedType.LPStr)] string secCodes);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_START_ORDERS")]
    public static partial void StartOrders(OrderStatusCallback orderStatusCallback);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_START_TRADES")]
    public static partial void StartTrades(TradeStatusCallback tradesStatusCallback);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_UNSUBSCRIBE_ORDERS")]
    public static partial int UnsubscribeOrders();

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_UNSUBSCRIBE_TRADES")]
    public static partial int UnsubscribeTrades();
}
