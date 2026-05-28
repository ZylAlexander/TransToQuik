using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions;

public class QuikConditionPriceByOtherSecStopOrder : QuikStopOrder
{
    /// <summary>
    /// Класс инструмента условия. Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC».
    /// </summary>
    public string StopPriceClasscode { get; set; } //Класс инструмента условия. Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC».  
    /// <summary>
    /// Код инструмента условия. Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC».
    /// </summary>
    public string StopPriceSeccode { get; set; } //Код инструмента условия. Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC» 
    /// <summary>
    /// Направление предельного изменения стоп-цены. Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC».        
    /// </summary>
    public QuikStopPriceCondition StopPriceCondition { get; set; } //Направление предельного изменения стоп-цены. 
    public override QuikStopOrderKind StopOrderKind => QuikStopOrderKind.ConditionPriceByOtherSec;

    protected override void AppendBody(StringBuilder sb)
    {
        base.AppendBody(sb);
        sb.AppendIfNotEmpty("STOPPRICE_CLASSCODE", StopPriceClasscode);
        sb.AppendIfNotEmpty("STOPPRICE_SECCODE", StopPriceSeccode);
        sb.AppendIfNotEmpty("STOPPRICE_CONDITION", StopPriceCondition.AsString());
    }

    protected override ValidationResult ValidateSelf()
    {
        if (string.IsNullOrWhiteSpace(StopPriceClasscode))
        {
            return ValidationResult.Failure("QuikConditionPriceByOtherSec: StopPriceClasscode must be provided");
        }

        if (string.IsNullOrWhiteSpace(StopPriceSeccode))
        {
            return ValidationResult.Failure("QuikConditionPriceByOtherSec: StopPriceSeccode must be provided");
        }

        return base.ValidateSelf();
    }
}
