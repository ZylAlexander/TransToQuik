using TransToQuik.Enums;

namespace TransToQuik.Interfaces;

public interface IQuikActivatedByOrder
{
    /// <summary>
    ///  Регистрационный номер заявки-условия. Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER» 
    /// </summary>
    uint BaseOrderKey { get; init; }
    /// <summary>
    /// Признак использования в качестве объема заявки «по исполнению» исполненного количества инструментов заявки-условия. Возможные значения: «YES» или «NO». Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER» 
    /// </summary>
    QuikYesNo UseBaseOrderBalance { get; init; }

    /// <summary>
    /// Признак активации заявки «по исполнению» при частичном исполнении заявки-условия. Возможные значения: «YES» или «NO». Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
    /// </summary>
    QuikYesNo ActivateIfBaseOrderPartlyFilled { get; init; }
}

