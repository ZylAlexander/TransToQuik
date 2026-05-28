using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions;

public abstract class QuikTakeProfitStopOrderBase : QuikStopOrder
{
    ///<summary>
    ///Величина отступа от максимума (минимума) цены последней сделки. Используется при «STOP_ORDER_KIND» = «TAKE_PROFIT_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER» 
    /// </summary>
    public required double Offset { get; init; }
    ///<summary>
    ///Единицы измерения отступа. Возможные значения: QuikUnits
    /// </summary>
    public required QuikUnits OffsetUnits { get; init; }
    ///<summary>
    ///Величина защитного спрэда. Используется при «STOP_ORDER_KIND» = «TAKE_PROFIT_STOP_ORDER» или ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER» 
    ///</summary>
    public required double Spread { get; init; }
    ///<summary>
    ///Единицы измерения защитного спрэда. Возможные значения: QuikUnits   
    ///</summary>
    public required QuikUnits SpreadUnits { get; init; }

    protected override void AppendBody(StringBuilder sb)
    {
        base.AppendBody(sb);
        sb.AppendIfNotEmpty("OFFSET", Offset.AsQuikPriceString(PriceScale));
        sb.AppendIfNotEmpty("OFFSET_UNITS", OffsetUnits.AsString());
        sb.AppendIfNotEmpty("SPREAD", Spread.AsQuikPriceString(PriceScale));
        sb.AppendIfNotEmpty("SPREAD_UNITS", SpreadUnits.AsString());
    }
    protected override ValidationResult ValidateSelf()
    {
        if (Offset < 0)
        {
            return ValidationResult.Failure("QuikTakeProfit: Offset cannot be negative");
        }

        if (Spread < 0)
        {
            return ValidationResult.Failure("QuikTakeProfit: Spread cannot be negative");
        }

        return base.ValidateSelf();
    }
}


