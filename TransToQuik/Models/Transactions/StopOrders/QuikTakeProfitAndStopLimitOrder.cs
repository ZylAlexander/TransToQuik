using System;
using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;


namespace TransToQuik.Models.Transactions;

public class QuikTakeProfitAndStopLimitOrder : QuikTakeProfitStopOrderBase
{
    /// <summary>
    /// Цена условия «стоп-лимит» для заявки типа «Тэйк-профит и стоп-лимит» 
    /// </summary>
    public required double StopPrice2 { get; init; }
    /// <summary>
    /// Признак исполнения заявки по рыночной цене при наступлении условия «стоп-лимит». Значения «YES» или «NO». Параметр заявок типа «Тэйк-профит и стоп-лимит» 
    /// </summary>
    public required QuikYesNo MarketStopLimit { get; init; }
    /// <summary>
    /// Признак исполнения заявки по рыночной цене при наступлении условия «тэйк-профит». Значения «YES» или «NO». Параметр заявок типа «Тэйк-профит и стоп-лимит» 
    /// </summary>
    public required QuikYesNo MarketTakeProfit { get; init; }
    /// <summary>
    /// Признак действия заявки типа «Тэйк-профит и стоп-лимит» в течение определенного интервала времени. Значения «YES» или «NO» 
    /// </summary>
    public required QuikYesNo IsActiveInTime { get; init; }
    /// <summary>
    /// Время начала действия заявки типа «Тэйк-профит и стоп-лимит» в формате «ЧЧММСС» 
    /// </summary>
    public required DateTime ActiveFromTime { get; init; }
    /// <summary>
    /// Время окончания действия заявки типа «Тэйк-профит и стоп-лимит» в формате «ЧЧММСС»         
    /// </summary>
    public required DateTime ActiveToTime { get; init; }
    public override QuikStopOrderKind StopOrderKind => QuikStopOrderKind.TakeProfitAndStopLimitOrder;

    protected override void AppendBody(StringBuilder sb)
    {
        base.AppendBody(sb);
        sb.AppendIfNotEmpty("STOPPRICE2", StopPrice2.AsQuikPriceString(PriceScale));
        sb.AppendIfNotEmpty("MARKET_STOP_LIMIT", MarketStopLimit.AsString());
        sb.AppendIfNotEmpty("MARKET_TAKE_PROFIT", MarketTakeProfit.AsString());
        sb.AppendIfNotEmpty("IS_ACTIVE_IN_TIME", IsActiveInTime.AsString());
        sb.AppendIfNotEmpty("ACTIVE_FROM_TIME", ActiveFromTime.ToString("HHmmss"));
        sb.AppendIfNotEmpty("ACTIVE_TO_TIME", ActiveToTime.ToString("HHmmss"));
    }

    protected override ValidationResult ValidateSelf()
    {
        if (StopPrice2 < 0)
        {
            return ValidationResult.Failure("QuikTakeProfitAndStopLimitOrder: StopPrice2 cannot be negative");
        }

        if (IsActiveInTime == QuikYesNo.Yes)
        {
            if (ActiveFromTime == default || ActiveToTime == default)
            {
                return ValidationResult.Failure("QuikTakeProfitAndStopLimitOrder: ActiveFromTime and ActiveToTime must be specified when IsActiveInTime is YES");
            }
        }

        return base.ValidateSelf();
    }
}
