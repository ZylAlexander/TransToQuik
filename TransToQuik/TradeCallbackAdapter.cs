using System;
using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransToQuik;

internal class TradeCallbackAdapter
{
    private readonly IQuikHandler<QuikTrade> _handler;

    public TradeCallbackAdapter(IQuikHandler<QuikTrade> handler)
    {
        _handler = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    public void TradeCallback(
        int mode,
        ulong number,
        ulong orderNum,
        string classCode,
        string secCode,
        double price,
        long qty,
        double value,
        int isSell,
        nint tradeDescriptor)
    {
        var details = TradeDetailsSnapshotFactory.Capture(QuikNativeWrapper.DefaultInstance, tradeDescriptor);
        var trade = new QuikTrade(
            mode,
            number,
            orderNum,
            classCode,
            secCode,
            price,
            qty,
            value,
            isSell,
            details);

        _handler.OnReply(trade);
    }
}
