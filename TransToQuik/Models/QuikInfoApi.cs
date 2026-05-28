using TransToQuik.Interfaces;

namespace TransToQuik.Models;

public record QuikInfoApi(
    IQuikTransactionInfoApi TransactionInfoApi,
    IQuikOrderInfoApi OrderInfoApi,
    IQuikTradeInfoApi TradeInfoApi) : IQuikInfoApi;

