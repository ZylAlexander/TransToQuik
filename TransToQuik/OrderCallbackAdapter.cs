using System;
using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransToQuik;

internal class OrderCallbackAdapter
{
    private readonly IQuikHandler<QuikOrder> _handler;

    public OrderCallbackAdapter(IQuikHandler<QuikOrder> handler)
    {
        _handler = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    public void OrderCallback(
        int mode,
        uint transId,
        ulong number,
        string classCode,
        string secCode,
        double price,
        long balance,
        double value,
        int isSell,
        int status,
        nint orderDescriptor)
    {
        var details = OrderDetailsSnapshotFactory.Capture(QuikNativeWrapper.DefaultInstance, orderDescriptor);
        var order = new QuikOrder(
            mode,
            transId,
            number,
            classCode,
            secCode,
            price,
            balance,
            value,
            isSell,
            status,
            details);

        _handler.OnReply(order);
    }
}
