using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions;

public abstract class QuikStopOrder : QuikOrderTransaction
{
    /// <summary>
    /// Стоп-цена, за единицу инструмента. Используется только при «ACTION» = «NEW_STOP_ORDER»
    /// </summary>
    public required double StopPrice { get; set; }
    /// <summary>
    /// Срок действия стоп-заявки. Возможные значения: QuikExpiryDate, кроме WITH_LINKED_LIMIT_ORDER – со связанной заявкой.
    /// </summary>
    public QuikExpiryDate? ExpiryDate { get; set; }
    /// <summary>
    /// Тип стоп-заявки.
    /// </summary>
    public abstract QuikStopOrderKind StopOrderKind { get; }
    public override QuikAction Action => QuikAction.NewStopOrder;
    protected override void AppendBody(StringBuilder sb)
    {
        base.AppendBody(sb);
        sb.AppendIfNotEmpty("STOPPRICE", StopPrice.AsQuikPriceString(PriceScale));
        sb.AppendIfNotEmpty("STOP_ORDER_KIND", StopOrderKind.AsString());
        sb.AppendIfNotEmpty("EXPIRY_DATE", ExpiryDate.AsString());
    }
    protected override ValidationResult ValidateSelf()
    {
        if (StopPrice < 0)
        {
            return ValidationResult.Failure("QuikStopLimit: StopPrice cannot be negative");
        }

        return base.ValidateSelf();
    }
}
