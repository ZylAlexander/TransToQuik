using System;

namespace TransToQuik.Models;

/// <summary>
/// Дополнительные поля сделки, снятые в потоке callback (дескриптор QUIK после callback недействителен).
/// </summary>
public readonly record struct QuikTradeDetails(
    int TradeDate,
    int TradeSettleDate,
    int TradeTime,
    int TradeIsMarginal,
    string TradeCurrency,
    string TradeSettleCurrency,
    string TradeSettleCode,
    double TradeAccruedInt,
    double TradeYield,
    string TradeUserId,
    string TradeAccount,
    string TradeBrokerRef,
    string TradeClientCode,
    string TradeFirmId,
    string TradePartnerFirmId,
    double TradeTsCommission,
    double ClearingCenterCommission,
    double TradeExchangeCommission,
    double TradeTradingSystemCommission,
    double TradePrice2,
    double TradeRepoRate,
    double TradeRepoValue,
    double TradeRepo2Value,
    double TradeAccruedInt2,
    int TradeRepoTerm,
    double TradeStartDiscount,
    double TradeLowerDiscount,
    double TradeUpperDiscount,
    string TradeExchangeCode,
    string TradeStationId,
    int TradeBlockSecurities,
    int TradePeriod,
    DateTime TradeFileTime,
    int TradeDatePlaced,
    int TradeTimePlaced,
    int TradeMicrosecondsPlaced,
    int TradeKind,
    double TradeBrokerCommission,
    int TradeTransId)
{
    public static QuikTradeDetails Empty => default;
}
