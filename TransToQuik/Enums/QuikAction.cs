using System.Runtime.Serialization;

namespace TransToQuik.Enums;

/// <summary>
/// Действия для Quik API
/// </summary>
[DataContract]
public enum QuikAction
{
    /// <summary>
    /// новая заявка
    /// </summary>
    [EnumMember(Value = "NEW_ORDER")]
    NewOrder,

    /// <summary>
    /// новая заявка на внебиржевую сделку
    /// </summary>
    [EnumMember(Value = "NEW_NEG_DEAL")]
    NewNegDeal,

    /// <summary>
    /// новая заявка на сделку РЕПО
    /// </summary>
    [EnumMember(Value = "NEW_REPO_NEG_DEAL")]
    NewRepoNegDeal,

    /// <summary>
    /// новая заявка на сделку модифицированного РЕПО (РЕПО-М)
    /// </summary>
    [EnumMember(Value = "NEW_EXT_REPO_NEG_DEAL")]
    NewExtRepoNegDeal,

    /// <summary>
    /// новая стоп-заявка
    /// </summary>
    [EnumMember(Value = "NEW_STOP_ORDER")]
    NewStopOrder,

    /// <summary>
    /// снять заявку
    /// </summary>
    [EnumMember(Value = "KILL_ORDER")]
    KillOrder,

    /// <summary>
    /// снять заявку на внебиржевую сделку или заявку на сделку РЕПО
    /// </summary>
    [EnumMember(Value = "KILL_NEG_DEAL")]
    KillNegDeal,

    /// <summary>
    /// снять стоп-заявку
    /// </summary>
    [EnumMember(Value = "KILL_STOP_ORDER")]
    KillStopOrder,

    /// <summary>
    /// снять все заявки из торговой системы (не поддерживается Trans2QUIK.dll, только tri-импорт)
    /// </summary>
    [EnumMember(Value = "KILL_ALL_ORDERS")]
    KillAllOrders,

    /// <summary>
    /// снять все стоп-заявки (не поддерживается Trans2QUIK.dll, только tri-импорт)
    /// </summary>
    [EnumMember(Value = "KILL_ALL_STOP_ORDERS")]
    KillAllStopOrders,

    /// <summary>
    /// снять все заявки на внебиржевые сделки и заявки на сделки РЕПО (не поддерживается Trans2QUIK.dll, только tri-импорт)
    /// </summary>
    [EnumMember(Value = "KILL_ALL_NEG_DEALS")]
    KillAllNegDeals,

    /// <summary>
    /// снять все заявки на рынке FORTS
    /// </summary>
    [EnumMember(Value = "KILL_ALL_FUTURES_ORDERS")]
    KillAllFuturesOrders,

    /// <summary>
    /// переставить заявки на рынке FORTS
    /// </summary>
    [EnumMember(Value = "MOVE_ORDERS")]
    MoveOrders,

    /// <summary>
    /// новая безадресная заявка
    /// </summary>
    [EnumMember(Value = "NEW_QUOTE")]
    NewQuote,

    /// <summary>
    /// снять безадресную заявку
    /// </summary>
    [EnumMember(Value = "KILL_QUOTE")]
    KillQuote,

    /// <summary>
    /// новая заявка-отчет о подтверждении транзакций в режимах РПС и РЕПО
    /// </summary>
    [EnumMember(Value = "NEW_REPORT")]
    NewReport,

    /// <summary>
    /// новое ограничение по фьючерсному счету
    /// </summary>
    [EnumMember(Value = "SET_FUT_LIMIT")]
    SetFutLimit
}