using System;
using TransToQuik.Models;

namespace TransToQuik.Extension;

public static class QuikTradeExtensions
{
    public static int TradeDate(this QuikTrade trade) => trade.Details.TradeDate;

    public static int TradeSettleDate(this QuikTrade trade) => trade.Details.TradeSettleDate;

    public static int TradeTime(this QuikTrade trade) => trade.Details.TradeTime;

    public static int TradeIsMarginal(this QuikTrade trade) => trade.Details.TradeIsMarginal;

    public static string TradeCurrency(this QuikTrade trade) => trade.Details.TradeCurrency;

    public static string TradeSettleCurrency(this QuikTrade trade) => trade.Details.TradeSettleCurrency;

    public static string TradeSettleCode(this QuikTrade trade) => trade.Details.TradeSettleCode;

    public static double TradeAccruedInt(this QuikTrade trade) => trade.Details.TradeAccruedInt;

    public static double TradeYield(this QuikTrade trade) => trade.Details.TradeYield;

    public static string TradeUserId(this QuikTrade trade) => trade.Details.TradeUserId;

    public static string TradeAccount(this QuikTrade trade) => trade.Details.TradeAccount;

    public static string TradeBrokerRef(this QuikTrade trade) => trade.Details.TradeBrokerRef;

    public static string TradeClientCode(this QuikTrade trade) => trade.Details.TradeClientCode;

    public static string TradeFirmId(this QuikTrade trade) => trade.Details.TradeFirmId;

    public static string TradePartnerFirmid(this QuikTrade trade) => trade.Details.TradePartnerFirmId;

    public static double TradeTSCommission(this QuikTrade trade) => trade.Details.TradeTsCommission;

    public static double ClearingCenterCommission(this QuikTrade trade) => trade.Details.ClearingCenterCommission;

    public static double TradeExchangeCommission(this QuikTrade trade) => trade.Details.TradeExchangeCommission;

    public static double TradeTradingSystemCommission(this QuikTrade trade) => trade.Details.TradeTradingSystemCommission;

    public static double TradePrice2(this QuikTrade trade) => trade.Details.TradePrice2;

    public static double TradeRepoRate(this QuikTrade trade) => trade.Details.TradeRepoRate;

    public static double TradeRepoValue(this QuikTrade trade) => trade.Details.TradeRepoValue;

    public static double TradeRepo2Value(this QuikTrade trade) => trade.Details.TradeRepo2Value;

    public static double TradeAccruedInt2(this QuikTrade trade) => trade.Details.TradeAccruedInt2;

    public static int TradeRepoTerm(this QuikTrade trade) => trade.Details.TradeRepoTerm;

    public static double TradeStartDiscount(this QuikTrade trade) => trade.Details.TradeStartDiscount;

    public static double TradeLowerDiscount(this QuikTrade trade) => trade.Details.TradeLowerDiscount;

    public static double TradeUpperDiscount(this QuikTrade trade) => trade.Details.TradeUpperDiscount;

    public static string TradeExchangeCode(this QuikTrade trade) => trade.Details.TradeExchangeCode;

    public static string TradeStationId(this QuikTrade trade) => trade.Details.TradeStationId;

    public static int TradeBlockSecurities(this QuikTrade trade) => trade.Details.TradeBlockSecurities;

    public static int TradePeriod(this QuikTrade trade) => trade.Details.TradePeriod;

    public static DateTime TradeFileTime(this QuikTrade trade) => trade.Details.TradeFileTime;

    public static int TradeDateTime(this QuikTrade trade, int timeType) =>
        timeType switch
        {
            0 => trade.Details.TradeDatePlaced,
            1 => trade.Details.TradeTimePlaced,
            2 => trade.Details.TradeMicrosecondsPlaced,
            _ => throw new ArgumentOutOfRangeException(nameof(timeType), timeType, "TimeType must be 0, 1, or 2."),
        };

    public static int TradeKind(this QuikTrade trade) => trade.Details.TradeKind;

    public static double TradeBrokerCommission(this QuikTrade trade) => trade.Details.TradeBrokerCommission;

    public static int TradeTransId(this QuikTrade trade) => trade.Details.TradeTransId;
}
