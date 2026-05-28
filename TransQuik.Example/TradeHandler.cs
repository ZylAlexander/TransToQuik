using TransToQuik.Extension;
using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransQuik.Example;

public sealed class TradeHandler : IQuikHandler<QuikTrade>
{
    public void OnReply(QuikTrade trade)
    {
        if (trade.Mode != 0)
        {
            return;
        }

        Console.WriteLine(
            $"[TRADE] #{trade.Number} order={trade.OrderNum} {trade.ClassCode}/{trade.SecCode} " +
            $"{trade.Operation} qty={trade.Qty} price={trade.Price} account={trade.TradeAccount()}");
    }
}
