using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions;

public class QuikWithLinkedLimitStopOrder : QuikStopOrder
{
    /// <summary>
    /// Цена связанной лимитированной заявки. Используется только при «STOP_ORDER_KIND» = «WITH_LINKED_LIMIT_ORDER».
    /// </summary>
    public required double LinkedOrderPrice { get; init; }

    /// <summary>
    /// Признак снятия стоп-заявки при частичном исполнении связанной лимитированной заявки. Используется только при «STOP_ORDER_KIND» = «WITH_LINKED_LIMIT_ORDER».
    /// Значения «YES» или «NO».
    /// </summary>
    public required QuikYesNo KillIfLinkedOrderPartlyFilled { get; init; }

    public override QuikStopOrderKind StopOrderKind => QuikStopOrderKind.WithLinkedLimitOrder;

    protected override void AppendBody(StringBuilder sb)
    {
        base.AppendBody(sb);
        sb.AppendIfNotEmpty("LINKED_ORDER_PRICE", LinkedOrderPrice.AsQuikPriceString(PriceScale));
        sb.AppendIfNotEmpty("KILL_IF_LINKED_ORDER_PARTLY_FILLED", KillIfLinkedOrderPartlyFilled.AsString());
    }
    protected override ValidationResult ValidateSelf()
    {
        if (LinkedOrderPrice < 0)
        {
            return ValidationResult.Failure("QWithLinkedLimitOrder: LinkedOrderPrice cannot be negative");
        }

        return base.ValidateSelf();
    }
}
