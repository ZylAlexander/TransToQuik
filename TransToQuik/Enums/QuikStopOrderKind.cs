using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikStopOrderKind
{
    /// <summary>
    ///  стоп-лимит 
    /// </summary>
    [EnumMember(Value = "SIMPLE_STOP_ORDER")]
    SimpleStopOrder,

    /// <summary>
    ///  с условием по другому инструменту 
    /// </summary>
    [EnumMember(Value = "CONDITION_PRICE_BY_OTHER_SEC")]
    ConditionPriceByOtherSec,

    /// <summary>
    ///  со связанной заявкой 
    /// </summary>
    [EnumMember(Value = "WITH_LINKED_LIMIT_ORDER")]
    WithLinkedLimitOrder,

    /// <summary>
    ///  тэйк-профит 
    /// </summary>
    [EnumMember(Value = "TAKE_PROFIT_STOP_ORDER")]
    TakeProfitStopOrder,

    /// <summary>
    ///   тэйк-профит и стоп-лимит 
    /// </summary>
    [EnumMember(Value = "TAKE_PROFIT_AND_STOP_LIMIT_ORDER")]
    TakeProfitAndStopLimitOrder,

    /// <summary>
    ///  стоп-лимит по исполнению заявки 
    /// </summary>
    [EnumMember(Value = "ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER")]
    ActivatedByOrderSimpleStopOrder,

    /// <summary>
    ///  тэйк-профит по исполнению заявки 
    /// </summary>
    [EnumMember(Value = "ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER")]
    ActivatedByOrderTakeProfitStopOrder,

    /// <summary>
    ///  тэйк-профит и стоп-лимит по исполнению заявки. 
    /// </summary>
    [EnumMember(Value = "ACTIVATED_BY_ORDER_TAKE_PROFIT_AND_STOP_LIMIT_ORDER")]
    ActivatedByOrderTakeProfitAndStopLimitOrder
}

