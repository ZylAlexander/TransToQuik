using System;
using System.Runtime.InteropServices;

namespace TransToQuik.Interop;

internal static partial class QuikNativeApi
{
    /// <summary>
    /// Возвращает количество (объём) заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Количество в заявке.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_QTY")]
    public static partial long OrderQty(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает дату заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Дата в формате YYYYMMDD.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_DATE")]
    public static partial int OrderDate(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает время заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Время в формате HHMMSS.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_TIME")]
    public static partial int OrderTime(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает время активации заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Время активации в формате HHMMSS.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_ACTIVATION_TIME")]
    public static partial int OrderActivationTime(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает время снятия заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Время снятия в формате HHMMSS.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_WITHDRAW_TIME")]
    public static partial int OrderWithdrawTime(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает дату окончания срока действия заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Дата окончания в формате YYYYMMDD.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_EXPIRY")]
    public static partial int OrderExpiry(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает накопленный купонный доход по заявке.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>НКД.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_ACCRUED_INT")]
    public static partial double OrderAccruedInt(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает доходность заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Доходность.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_YIELD")]
    public static partial double OrderYield(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает идентификатор трейдера, от имени которого выставлена заявка.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Строка User ID (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_USERID")]
    public static partial IntPtr OrderUserId(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает UserID пользователя, поставившего заявку.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Числовой UserID.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_UID")]
    public static partial int OrderUID(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает торговый счёт, указанный в заявке.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Код счёта (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_ACCOUNT")]
    public static partial IntPtr OrderAccount(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает комментарий заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Brokerref (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_BROKERREF")]
    public static partial IntPtr OrderBrokerRef(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает код клиента, указанный в заявке.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Код клиента (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_CLIENT_CODE")]
    public static partial IntPtr OrderClientCode(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает идентификатор фирмы-участника торгов, указанный в заявке.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Код фирмы (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_FIRMID")]
    public static partial IntPtr OrderFirmId(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает видимое количество для заявок типа «по объёму».
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Видимое количество.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_VISIBLE_QTY")]
    public static partial long OrderVisibleQTY(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает период, когда заявка может быть исполнена.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>0 — немедленно, 1 — сессионно, 2 — бессрочно.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_PERIOD")]
    public static partial int OrderPeriod(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает дату и время выставления заявки в формате FILETIME.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>FILETIME (UTC).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_FILETIME")]
    public static partial long OrderFileTime(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает дату и время снятия заявки в формате FILETIME.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>FILETIME (UTC).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_WITHDRAW_FILETIME")]
    public static partial long OrderWithdrawFileTime(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает компонент даты/времени заявки в зависимости от <paramref name="timeType"/>.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <param name="timeType">0 — дата выставления (YYYYMMDD), 1 — время выставления (HHMMSS), 2 — микросекунды выставления, 3 — дата снятия, 4 — время снятия, 5 — микросекунды снятия.</param>
    /// <returns>Запрошенный компонент даты/времени.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_DATE_TIME")]
    public static partial int OrderDateTime(IntPtr orderDescriptor, int timeType);

    /// <summary>
    /// Возвращает способ указания объёма заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>0 — не определён, 1 — количество, 2 — объём.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_VALUE_ENTRY_TYPE")]
    public static partial int OrderValueEntryType(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает расширенные флаги заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Битовая маска флагов.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_EXTENDED_FLAGS")]
    public static partial int OrderExtendedFlags(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает минимально допустимое количество.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Минимальное количество; 0 — ограничение не задано.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_MIN_QTY")]
    public static partial int OrderMinQTY(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает тип исполнения заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Код типа исполнения; 0 — значение не задано.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_EXEC_TYPE")]
    public static partial int OrderExecType(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает среднюю цену приобретения при частичном исполнении заявки.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Средняя цена.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_AWG_PRICE")]
    public static partial double OrderAwgPrice(IntPtr orderDescriptor);

    /// <summary>
    /// Возвращает причину отклонения заявки брокером.
    /// </summary>
    /// <param name="orderDescriptor">Дескриптор заявки из callback TRANS2QUIK.</param>
    /// <returns>Текст причины (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_ORDER_REJECT_REASON")]
    public static partial IntPtr OrderRejectReason(IntPtr orderDescriptor);
}
