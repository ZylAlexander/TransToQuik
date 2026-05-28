using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models;

public readonly record struct QuikTrade
{
    public QuikMode Mode { get; }
    public ulong Number { get; }
    public ulong OrderNum { get; }
    public string ClassCode { get; }
    public string SecCode { get; }
    public double Price { get; }
    public long Qty { get; }
    public double Value { get; }
    public QuikOperation Operation { get; }

    /// <summary>
    /// Дополнительные поля сделки, снятые в callback. Безопасно использовать после выхода из <see cref="IQuikHandler{T}.OnReply"/>.
    /// </summary>
    public QuikTradeDetails Details { get; }

    public QuikTrade(
        int mode,
        ulong number,
        ulong orderNum,
        string classCode,
        string secCode,
        double price,
        long qty,
        double value,
        int isSell,
        QuikTradeDetails details)
    {
        Mode = (QuikMode)mode;
        Number = number;
        OrderNum = orderNum;
        ClassCode = classCode;
        SecCode = secCode;
        Price = price;
        Qty = qty;
        Value = value;
        Operation = isSell == 0 ? QuikOperation.Buy : QuikOperation.Sell;
        Details = details;
    }
}
