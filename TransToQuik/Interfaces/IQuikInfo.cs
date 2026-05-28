namespace TransToQuik.Interfaces;

public interface IQuikInfoApi
{
    IQuikTransactionInfoApi TransactionInfoApi { get; }
    IQuikOrderInfoApi OrderInfoApi { get; }
    IQuikTradeInfoApi TradeInfoApi { get; }
}
