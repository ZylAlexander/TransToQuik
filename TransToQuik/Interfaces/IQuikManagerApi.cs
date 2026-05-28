using TransToQuik.Interop;

namespace TransToQuik.Interfaces;

public interface IQuikManagerApi
{
    int SendSyncTransaction(
        string serializedTransaction,
            out int replyCode,
            out uint transId,
            out ulong OrderNum,
            byte[] ResultMessage,
            uint ResultMessageSize,
            out int ExtendedErrorCode,
            byte[] ErrorMessage, uint ErrorMessageSize);
    int SendAsyncTransaction(string serializedTransaction, out int errorCode, byte[] errorMessage, uint errorMessageSize);
    int SetTransactionsReplyCallback(TransactionReplyCallback pfTransactionReplyCallback, out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize);
    int SubscribeOrders(string ClassCode, string Seccodes);
    int SubscribeTrades(string ClassCode, string Seccodes);
    void StartOrders(OrderStatusCallback FuncOrderStatusCallback);
    void StartTrades(TradeStatusCallback FuncTradesStatusCallback);
    int UnsubscribeOrders();
    int UnsubscribeTrades();
}