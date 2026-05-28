using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransToQuik;

internal static class TradeDetailsSnapshotFactory
{
    public static QuikTradeDetails Capture(IQuikTradeInfoApi api, nint tradeDescriptor)
    {
        if (tradeDescriptor == nint.Zero)
        {
            return QuikTradeDetails.Empty;
        }

        return new QuikTradeDetails(
            api.TradeDate(tradeDescriptor),
            api.TradeSettleDate(tradeDescriptor),
            api.TradeTime(tradeDescriptor),
            api.TradeIsMarginal(tradeDescriptor),
            api.TradeCurrency(tradeDescriptor),
            api.TradeSettleCurrency(tradeDescriptor),
            api.TradeSettleCode(tradeDescriptor),
            api.TradeAccruedInt(tradeDescriptor),
            api.TradeYield(tradeDescriptor),
            api.TradeUserId(tradeDescriptor),
            api.TradeAccount(tradeDescriptor),
            api.TradeBrokerRef(tradeDescriptor),
            api.TradeClientCode(tradeDescriptor),
            api.TradeFirmId(tradeDescriptor),
            api.TradePartnerFirmid(tradeDescriptor),
            api.TradeTSCommission(tradeDescriptor),
            api.ClearingCenterCommission(tradeDescriptor),
            api.TradeExchangeCommission(tradeDescriptor),
            api.TradeTradingSystemCommission(tradeDescriptor),
            api.TradePrice2(tradeDescriptor),
            api.TradeRepoRate(tradeDescriptor),
            api.TradeRepoValue(tradeDescriptor),
            api.TradeRepo2Value(tradeDescriptor),
            api.TradeAccruedInt2(tradeDescriptor),
            api.TradeRepoTerm(tradeDescriptor),
            api.TradeStartDiscount(tradeDescriptor),
            api.TradeLowerDiscount(tradeDescriptor),
            api.TradeUpperDiscount(tradeDescriptor),
            api.TradeExchangeCode(tradeDescriptor),
            api.TradeStationId(tradeDescriptor),
            api.TradeBlockSecurities(tradeDescriptor),
            api.TradePeriod(tradeDescriptor),
            api.TradeFileTime(tradeDescriptor),
            api.TradeDateTime(tradeDescriptor, 0),
            api.TradeDateTime(tradeDescriptor, 1),
            api.TradeDateTime(tradeDescriptor, 2),
            api.TradeKind(tradeDescriptor),
            api.TradeBrokerCommission(tradeDescriptor),
            api.TradeTransId(tradeDescriptor));
    }
}
