using System;
using TransToQuik.Extension;
using TransToQuik.Interfaces;
using TransToQuik.Interop;

namespace TransToQuik;

internal class QuikNativeWrapper : IQuikConnectionApi, IQuikManagerApi, IQuikTransactionInfoApi, IQuikOrderInfoApi, IQuikTradeInfoApi
{
    private static string FromIntPtr(Func<nint, nint> action, nint replyDescriptor)
    {
        if (replyDescriptor == nint.Zero)
        {
            return null;
        }

        var intPtr = action?.Invoke(replyDescriptor);
        return intPtr is null ? null : NativeStringExtensions.PtrToQuikString(intPtr.Value);
    }

    private static string FromIntPtr(Func<nint, int, nint> action, nint replyDescriptor, int orderId)
    {
        if (replyDescriptor == nint.Zero)
        {
            return null;
        }

        var intPtr = action?.Invoke(replyDescriptor, orderId);
        return intPtr is null ? null : NativeStringExtensions.PtrToQuikString(intPtr.Value);
    }

    public static QuikNativeWrapper DefaultInstance => new();

    private QuikNativeWrapper() { }

    #region Connection
    public int Connect(string PathToInfo, out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize) =>
            QuikNativeApi.Connect(PathToInfo, out ExtendedErrorCode, ErrorMessage, ErrorMessageSize);
    public int Disconnect(out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize) =>
        QuikNativeApi.Disconnect(out ExtendedErrorCode, ErrorMessage, ErrorMessageSize);

    public int IsDllConnected(out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize) =>
        QuikNativeApi.IsDllConnected(out ExtendedErrorCode, ErrorMessage, ErrorMessageSize);
    public int IsQuikConnected(out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize) =>
        QuikNativeApi.IsQuikConnected(out ExtendedErrorCode, ErrorMessage, ErrorMessageSize);
    public int SetConnectionStatusCallback(
        ConnectionStatusCallback ConnectionStatusCallback,
            out int ExtendedErrorCode,
            byte[] ErrorMessage,
            uint ErrorMessageSize) =>
        QuikNativeApi.SetConnectionStatusCallback(
            ConnectionStatusCallback,
            out ExtendedErrorCode,
            ErrorMessage,
            ErrorMessageSize);
    #endregion

    #region Manage Api
    public int SendAsyncTransaction(string serializedTransaction, out int errorCode, byte[] errorMessage, uint errorMessageSize) =>
        QuikNativeApi.SendAsyncTransaction(serializedTransaction, out errorCode, errorMessage, errorMessageSize);
    public int SendSyncTransaction(
            string serializedTransaction,
            out int replyCode,
            out uint transId,
            out ulong OrderNum,
            byte[] ResultMessage,
            uint ResultMessageSize,
            out int ExtendedErrorCode,
            byte[] ErrorMessage, uint ErrorMessageSize) =>
        QuikNativeApi.SendSyncTransaction(
            serializedTransaction,
            out replyCode,
            out transId,
            out OrderNum,
            ResultMessage,
            ResultMessageSize,
            out ExtendedErrorCode,
            ErrorMessage,
            ErrorMessageSize);
    public int SetTransactionsReplyCallback(
        TransactionReplyCallback transactionReplyCallback,
            out int extendedErrorCode,
            byte[] errorMessage,
            uint errorMessageSize) =>
        QuikNativeApi.SetTransactionsReplyCallback(transactionReplyCallback, out extendedErrorCode, errorMessage, errorMessageSize);
    public void StartOrders(OrderStatusCallback orderStatusCallback) => QuikNativeApi.StartOrders(orderStatusCallback);
    public void StartTrades(TradeStatusCallback tradesStatusCallback) => QuikNativeApi.StartTrades(tradesStatusCallback);
    public int SubscribeOrders(string classCode, string seccodes) => QuikNativeApi.SubscribeOrders(classCode, seccodes);
    public int SubscribeTrades(string classCode, string seccodes) => QuikNativeApi.SubscribeTrades(classCode, seccodes);
    public int UnsubscribeOrders() => QuikNativeApi.UnsubscribeOrders();
    public int UnsubscribeTrades() => QuikNativeApi.UnsubscribeTrades();
    #endregion

    #region TransactionInfo
    public string Account(nint replyDescriptor) => FromIntPtr(QuikNativeApi.Account, replyDescriptor);
    public long Balance(nint replyDescriptor) => QuikNativeApi.Balance(replyDescriptor);
    public string BrokerRef(nint replyDescriptor) => FromIntPtr(QuikNativeApi.BrokerRef, replyDescriptor);
    public string ClassCode(nint replyDescriptor) => FromIntPtr(QuikNativeApi.ClassCode, replyDescriptor);
    public string ClientCode(nint replyDescriptor) => FromIntPtr(QuikNativeApi.ClientCode, replyDescriptor);
    public string ExchangeCode(nint replyDescriptor) => FromIntPtr(QuikNativeApi.ExchangeCode, replyDescriptor);
    public string FirmId(nint replyDescriptor) => FromIntPtr(QuikNativeApi.FirmId, replyDescriptor);
    public double Price(nint replyDescriptor) => QuikNativeApi.Price(replyDescriptor);
    public long Quantity(nint replyDescriptor) => QuikNativeApi.Quantity(replyDescriptor);
    public string SecCode(nint replyDescriptor) => FromIntPtr(QuikNativeApi.SecCode, replyDescriptor);
    public short TransactionReplyOrdersCount(nint tradeDescriptor) => QuikNativeApi.TransactionReplyOrdersCount(tradeDescriptor);
    public int TransactionReplyFirstOrderNumberById(nint tradeDescriptor, int orderId) => QuikNativeApi.TransactionReplyFirstOrderNumberById(tradeDescriptor, orderId);
    public int TransactionReplyOrderNumberById(nint tradeDescriptor, int orderId) => QuikNativeApi.TransactionReplyOrderNumberById(tradeDescriptor, orderId);
    public double TransactionReplyPriceById(nint tradeDescriptor, int orderId) => QuikNativeApi.TransactionReplyPriceById(tradeDescriptor, orderId);
    public long TransactionReplyQuantityById(nint tradeDescriptor, int orderId) => QuikNativeApi.TransactionReplyQuantityById(tradeDescriptor, orderId);
    public long TransactionReplyBalanceById(nint tradeDescriptor, int orderId) => QuikNativeApi.TransactionReplyBalanceById(tradeDescriptor, orderId);
    public string TransactionReplyFirmidById(nint tradeDescriptor, int orderId) => FromIntPtr(QuikNativeApi.TransactionReplyFirmidById, tradeDescriptor, orderId);
    public string TransactionReplyAccountById(nint tradeDescriptor, int orderId) => FromIntPtr(QuikNativeApi.TransactionReplyAccountById, tradeDescriptor, orderId);
    public string TransactionReplyClientCodeById(nint tradeDescriptor, int orderId) => FromIntPtr(QuikNativeApi.TransactionReplyClientCodeById, tradeDescriptor, orderId);
    public string TransactionReplyBrokerrefById(nint tradeDescriptor, int orderId) => FromIntPtr(QuikNativeApi.TransactionReplyBrokerrefById, tradeDescriptor, orderId);
    #endregion

    #region OrderInfo
    public long OrderQty(nint orderDescriptor) => QuikNativeApi.OrderQty(orderDescriptor);
    public int OrderDate(nint orderDescriptor) => QuikNativeApi.OrderDate(orderDescriptor);
    public int OrderTime(nint orderDescriptor) => QuikNativeApi.OrderTime(orderDescriptor);
    public int OrderActivationTime(nint orderDescriptor) => QuikNativeApi.OrderActivationTime(orderDescriptor);
    public int OrderWithdrawTime(nint orderDescriptor) => QuikNativeApi.OrderWithdrawTime(orderDescriptor);
    public int OrderExpiry(nint orderDescriptor) => QuikNativeApi.OrderExpiry(orderDescriptor);
    public double OrderAccruedInt(nint orderDescriptor) => QuikNativeApi.OrderAccruedInt(orderDescriptor);
    public double OrderYield(nint orderDescriptor) => QuikNativeApi.OrderYield(orderDescriptor);
    public string OrderUserId(nint orderDescriptor) => FromIntPtr(QuikNativeApi.OrderUserId, orderDescriptor);
    public int OrderUID(nint orderDescriptor) => QuikNativeApi.OrderUID(orderDescriptor);
    public string OrderAccount(nint orderDescriptor) => FromIntPtr(QuikNativeApi.OrderAccount, orderDescriptor);
    public string OrderBrokerRef(nint orderDescriptor) => FromIntPtr(QuikNativeApi.OrderBrokerRef, orderDescriptor);
    public string OrderClientCode(nint orderDescriptor) => FromIntPtr(QuikNativeApi.OrderClientCode, orderDescriptor);
    public string OrderFirmId(nint orderDescriptor) => FromIntPtr(QuikNativeApi.OrderFirmId, orderDescriptor);
    public long OrderVisibleQTY(nint orderDescriptor) => QuikNativeApi.OrderVisibleQTY(orderDescriptor);
    public int OrderPeriod(nint orderDescriptor) => QuikNativeApi.OrderPeriod(orderDescriptor);
    public DateTime OrderFileTime(nint orderDescriptor) => DateTime.FromFileTimeUtc(QuikNativeApi.OrderFileTime(orderDescriptor));
    public DateTime OrderWithdrawFileTime(nint orderDescriptor) => DateTime.FromFileTimeUtc(QuikNativeApi.OrderWithdrawFileTime(orderDescriptor));
    public int OrderDateTime(nint orderDescriptor, int timeType) => QuikNativeApi.OrderDateTime(orderDescriptor, timeType);
    public int OrderValueEntryType(nint orderDescriptor) => QuikNativeApi.OrderValueEntryType(orderDescriptor);
    public int OrderExtendedFlags(nint orderDescriptor) => QuikNativeApi.OrderExtendedFlags(orderDescriptor);
    public int OrderMinQTY(nint orderDescriptor) => QuikNativeApi.OrderMinQTY(orderDescriptor);
    public int OrderExecType(nint orderDescriptor) => QuikNativeApi.OrderExecType(orderDescriptor);
    public double OrderAwgPrice(nint orderDescriptor) => QuikNativeApi.OrderAwgPrice(orderDescriptor);
    public string OrderRejectReason(nint orderDescriptor) => FromIntPtr(QuikNativeApi.OrderRejectReason, orderDescriptor);
    #endregion

    #region TradeInfo
    public int TradeDate(nint tradeDescriptor) => QuikNativeApi.TradeDate(tradeDescriptor);
    public int TradeSettleDate(nint tradeDescriptor) => QuikNativeApi.TradeSettleDate(tradeDescriptor);
    public int TradeTime(nint tradeDescriptor) => QuikNativeApi.TradeTime(tradeDescriptor);
    public int TradeIsMarginal(nint tradeDescriptor) => QuikNativeApi.TradeIsMarginal(tradeDescriptor);
    public string TradeCurrency(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeCurrency, tradeDescriptor);
    public string TradeSettleCurrency(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeSettleCurrency, tradeDescriptor);
    public string TradeSettleCode(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeSettleCode, tradeDescriptor);
    public double TradeAccruedInt(nint tradeDescriptor) => QuikNativeApi.TradeAccruedInt(tradeDescriptor);
    public double TradeYield(nint tradeDescriptor) => QuikNativeApi.TradeYield(tradeDescriptor);
    public string TradeUserId(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeUserId, tradeDescriptor);
    public string TradeAccount(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeAccount, tradeDescriptor);
    public string TradeBrokerRef(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeBrokerRef, tradeDescriptor);
    public string TradeClientCode(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeClientCode, tradeDescriptor);
    public string TradeFirmId(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeFirmId, tradeDescriptor);
    public string TradePartnerFirmid(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradePartnerFirmid, tradeDescriptor);
    public double TradeTSCommission(nint tradeDescriptor) => QuikNativeApi.TradeTSCommission(tradeDescriptor);
    public double ClearingCenterCommission(nint tradeDescriptor) => QuikNativeApi.ClearingCenterCommission(tradeDescriptor);
    public double TradeExchangeCommission(nint tradeDescriptor) => QuikNativeApi.TradeExchangeCommission(tradeDescriptor);
    public double TradeTradingSystemCommission(nint tradeDescriptor) => QuikNativeApi.TradeTradingSystemCommission(tradeDescriptor);
    public double TradePrice2(nint tradeDescriptor) => QuikNativeApi.TradePrice2(tradeDescriptor);
    public double TradeRepoRate(nint tradeDescriptor) => QuikNativeApi.TradeRepoRate(tradeDescriptor);
    public double TradeRepoValue(nint tradeDescriptor) => QuikNativeApi.TradeRepoValue(tradeDescriptor);
    public double TradeRepo2Value(nint tradeDescriptor) => QuikNativeApi.TradeRepo2Value(tradeDescriptor);
    public double TradeAccruedInt2(nint tradeDescriptor) => QuikNativeApi.TradeAccruedInt2(tradeDescriptor);
    public int TradeRepoTerm(nint tradeDescriptor) => QuikNativeApi.TradeRepoTerm(tradeDescriptor);
    public double TradeStartDiscount(nint tradeDescriptor) => QuikNativeApi.TradeStartDiscount(tradeDescriptor);
    public double TradeLowerDiscount(nint tradeDescriptor) => QuikNativeApi.TradeLowerDiscount(tradeDescriptor);
    public double TradeUpperDiscount(nint tradeDescriptor) => QuikNativeApi.TradeUpperDiscount(tradeDescriptor);
    public string TradeExchangeCode(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeExchangeCode, tradeDescriptor);
    public string TradeStationId(nint tradeDescriptor) => FromIntPtr(QuikNativeApi.TradeStationId, tradeDescriptor);
    public int TradeBlockSecurities(nint tradeDescriptor) => QuikNativeApi.TradeBlockSecurities(tradeDescriptor);
    public int TradePeriod(nint tradeDescriptor) => QuikNativeApi.TradePeriod(tradeDescriptor);
    public DateTime TradeFileTime(nint tradeDescriptor) => DateTime.FromFileTimeUtc(QuikNativeApi.TradeFileTime(tradeDescriptor));
    public int TradeDateTime(nint tradeDescriptor, int timeType) => QuikNativeApi.TradeDateTime(tradeDescriptor, timeType);
    public int TradeKind(nint tradeDescriptor) => QuikNativeApi.TradeKind(tradeDescriptor);
    public double TradeBrokerCommission(nint tradeDescriptor) => QuikNativeApi.TradeBrokerCommission(tradeDescriptor);
    public int TradeTransId(nint tradeDescriptor) => QuikNativeApi.TradeTransId(tradeDescriptor);
    #endregion
}
