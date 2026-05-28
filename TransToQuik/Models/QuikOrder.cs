using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models;

public readonly record struct QuikOrder
{
    public QuikMode Mode { get; }
    public uint TransID { get; }
    public ulong Number { get; }
    public string ClassCode { get; }
    public string SecCode { get; }
    public double Price { get; }
    public long Balance { get; }
    public double Value { get; }
    public QuikOperation Operation { get; }
    public QuikOrderStatus Status { get; }

    /// <summary>
    /// Дополнительные поля заявки, снятые в callback. Безопасно использовать после выхода из <see cref="IQuikHandler{T}.OnReply"/>.
    /// </summary>
    public QuikOrderDetails Details { get; }

    public QuikOrder(
        int mode,
        uint transID,
        ulong number,
        string classCode,
        string secCode,
        double price,
        long balance,
        double value,
        int isSell,
        int status,
        QuikOrderDetails details)
    {
        Mode = (QuikMode)mode;
        TransID = transID;
        Number = number;
        ClassCode = classCode;
        SecCode = secCode;
        Price = price;
        Balance = balance;
        Value = value;
        Operation = isSell == 0 ? QuikOperation.Buy : QuikOperation.Sell;
        Status = EnumExtensions.GetValueOrDefault(status, QuikOrderStatus.Unknown);
        Details = details;
    }
}
