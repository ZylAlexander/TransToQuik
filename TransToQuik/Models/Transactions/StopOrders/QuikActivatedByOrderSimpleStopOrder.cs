using System;
using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;
using TransToQuik.Interfaces;

namespace TransToQuik.Models.Transactions;

public class QuikActivatedByOrderSimpleStopOrder : QuikStopOrder, IQuikActivatedByOrder
{
    /// <summary>
    ///  Регистрационный номер заявки-условия. Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
    /// </summary>
    public required uint BaseOrderKey { get; init; }
    /// <summary>
    /// Признак использования в качестве объема заявки «по исполнению» исполненного количества инструментов заявки-условия. Возможные значения: «YES» или «NO». Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
    /// </summary>
    public required QuikYesNo UseBaseOrderBalance { get; init; }
    /// <summary>
    /// Признак активации заявки «по исполнению» при частичном исполнении заявки-условия. Возможные значения: «YES» или «NO». Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
    /// </summary>
    public required QuikYesNo ActivateIfBaseOrderPartlyFilled { get; init; }
    public override QuikStopOrderKind StopOrderKind => QuikStopOrderKind.ActivatedByOrderSimpleStopOrder;
    protected override void AppendBody(StringBuilder sb)
    {
        base.AppendBody(sb);
        sb.AppendIfNotEmpty("BASE_ORDER_KEY", BaseOrderKey.ToString());
        sb.AppendIfNotEmpty("USE_BASE_ORDER_BALANCE", UseBaseOrderBalance.AsString());
        sb.AppendIfNotEmpty("ACTIVATE_IF_BASE_ORDER_PARTLY_FILLED", ActivateIfBaseOrderPartlyFilled.AsString());
    }
    protected override ValidationResult ValidateSelf()
    {
        if (BaseOrderKey <= 0)
        {
            return ValidationResult.Failure("QuikActivatedByOrderSimpleStopOrder: BaseOrderKey must be greater than 0");
        }

        return base.ValidateSelf();
    }
}
