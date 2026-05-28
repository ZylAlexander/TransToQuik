using TransToQuik.Extension;
using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransQuik.Example;

public sealed class OrderHandler : IQuikHandler<QuikOrder>
{
    public void OnReply(QuikOrder order)
    {
        if (order.Mode != 0)
        {
            return;
        }

        Console.WriteLine(
            $"[ORDER] #{order.Number} {order.ClassCode}/{order.SecCode} " +
            $"{order.Operation} qty={order.Balance} price={order.Price} status={order.Status} " +
            $"account={order.OrderAccount()}");
    }
}
