using System;

namespace TransToQuik.Interfaces;

public interface IQuikTradeInfoApi
{
    int TradeDate(IntPtr tradeDescriptor);
    int TradeSettleDate(IntPtr tradeDescriptor);
    int TradeTime(IntPtr tradeDescriptor);
    int TradeIsMarginal(IntPtr tradeDescriptor);
    string TradeCurrency(IntPtr tradeDescriptor);
    string TradeSettleCurrency(IntPtr tradeDescriptor);
    string TradeSettleCode(IntPtr tradeDescriptor);
    double TradeAccruedInt(IntPtr tradeDescriptor);
    double TradeYield(IntPtr tradeDescriptor);
    string TradeUserId(IntPtr tradeDescriptor);
    string TradeAccount(IntPtr tradeDescriptor);
    string TradeBrokerRef(IntPtr tradeDescriptor);
    string TradeClientCode(IntPtr tradeDescriptor);
    string TradeFirmId(IntPtr tradeDescriptor);
    string TradePartnerFirmid(IntPtr tradeDescriptor);
    double TradeTSCommission(IntPtr tradeDescriptor);
    double ClearingCenterCommission(IntPtr tradeDescriptor);
    double TradeExchangeCommission(IntPtr tradeDescriptor);
    double TradeTradingSystemCommission(IntPtr tradeDescriptor);
    double TradePrice2(IntPtr tradeDescriptor);
    double TradeRepoRate(IntPtr tradeDescriptor);
    double TradeRepoValue(IntPtr tradeDescriptor);
    double TradeRepo2Value(IntPtr tradeDescriptor);
    double TradeAccruedInt2(IntPtr tradeDescriptor);
    int TradeRepoTerm(IntPtr tradeDescriptor);
    double TradeStartDiscount(IntPtr tradeDescriptor);
    double TradeLowerDiscount(IntPtr tradeDescriptor);
    double TradeUpperDiscount(IntPtr tradeDescriptor);
    string TradeExchangeCode(IntPtr tradeDescriptor);
    string TradeStationId(IntPtr tradeDescriptor);
    int TradeBlockSecurities(IntPtr tradeDescriptor);
    int TradePeriod(IntPtr tradeDescriptor);
    DateTime TradeFileTime(IntPtr tradeDescriptor);
    int TradeDateTime(IntPtr tradeDescriptor, int TimeType);
    int TradeKind(IntPtr tradeDescriptor);
    double TradeBrokerCommission(IntPtr tradeDescriptor);
    int TradeTransId(IntPtr tradeDescriptor);
}