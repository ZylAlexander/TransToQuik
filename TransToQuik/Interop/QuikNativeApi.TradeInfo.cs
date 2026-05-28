using System;
using System.Runtime.InteropServices;

namespace TransToQuik.Interop;

internal static partial class QuikNativeApi
{
    /// <summary>
    /// Возвращает дату заключения сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Дата в формате YYYYMMDD.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_DATE")]
    public static partial int TradeDate(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает дату расчётов по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Дата расчётов в формате YYYYMMDD.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_SETTLE_DATE")]
    public static partial int TradeSettleDate(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает время сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Время в формате HHMMSS.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_TIME")]
    public static partial int TradeTime(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает признак маржинальной сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>0 - немаржинальная, иначе - маржинальная.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_IS_MARGINAL")]
    public static partial int TradeIsMarginal(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает валюту, в которой выражена цена сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код валюты (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_CURRENCY")]
    public static partial IntPtr TradeCurrency(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает валюту расчётов по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код валюты расчётов (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_SETTLE_CURRENCY")]
    public static partial IntPtr TradeSettleCurrency(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает код расчётов по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код расчётов (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_SETTLE_CODE")]
    public static partial IntPtr TradeSettleCode(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает накопленный купонный доход по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>НКД.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_ACCRUED_INT")]
    public static partial double TradeAccruedInt(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает доходность сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Доходность.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_YIELD")]
    public static partial double TradeYield(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает идентификатор трейдера, от имени которого заключена сделка.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Строка User ID (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_USERID")]
    public static partial IntPtr TradeUserId(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает торговый счёт сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код счёта (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_ACCOUNT")]
    public static partial IntPtr TradeAccount(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает комментарий сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Brokerref (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_BROKERREF")]
    public static partial IntPtr TradeBrokerRef(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает код клиента сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код клиента (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_CLIENT_CODE")]
    public static partial IntPtr TradeClientCode(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает идентификатор фирмы-участника торгов по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код фирмы (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_FIRMID")]
    public static partial IntPtr TradeFirmId(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает идентификатор фирмы-контрагента по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код фирмы контрагента (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_PARTNER_FIRMID")]
    public static partial IntPtr TradePartnerFirmid(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает комиссию торговой системы по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Размер комиссии.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_TS_COMMISSION")]
    public static partial double TradeTSCommission(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает комиссию клирингового центра по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Размер комиссии.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_CLEARING_CENTER_COMMISSION")]
    public static partial double ClearingCenterCommission(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает биржевую комиссию по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Размер комиссии.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_EXCHANGE_COMMISSION")]
    public static partial double TradeExchangeCommission(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает комиссию торговой системы (альтернативный параметр) по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Размер комиссии.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_TRADING_SYSTEM_COMMISSION")]
    public static partial double TradeTradingSystemCommission(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает цену выкупа (вторая цена) по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Цена Price2.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_PRICE2")]
    public static partial double TradePrice2(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает ставку РЕПО в процентах.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Ставка РЕПО.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_REPO_RATE")]
    public static partial double TradeRepoRate(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает сумму РЕПО (стоимость первой части/выкупа по сделке РЕПО).
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Сумма РЕПО.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_REPO_VALUE")]
    public static partial double TradeRepoValue(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает сумму выкупа (вторая часть РЕПО).
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Сумма второй части РЕПО.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_REPO2_VALUE")]
    public static partial double TradeRepo2Value(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает накопленный купонный доход по второй части сделки РЕПО.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>НКД второй части.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_ACCRUED_INT2")]
    public static partial double TradeAccruedInt2(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает срок РЕПО в календарных днях.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Срок в днях.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_REPO_TERM")]
    public static partial int TradeRepoTerm(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает начальный дисконт по сделке РЕПО.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Начальный дисконт.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_START_DISCOUNT")]
    public static partial double TradeStartDiscount(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает нижний дисконт по сделке РЕПО.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Нижний дисконт.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_LOWER_DISCOUNT")]
    public static partial double TradeLowerDiscount(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает верхний дисконт по сделке РЕПО.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Верхний дисконт.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_UPPER_DISCOUNT")]
    public static partial double TradeUpperDiscount(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает код биржи.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Код биржи (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_EXCHANGE_CODE")]
    public static partial IntPtr TradeExchangeCode(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает идентификатор рабочей станции.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Идентификатор станции (указатель на ANSI-строку в памяти QUIK).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_STATION_ID")]
    public static partial IntPtr TradeStationId(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает признак блокировки ценных бумаг на время РЕПО.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>0 - не блокируются, иначе - блокируются.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_BLOCK_SECURITIES")]
    public static partial int TradeBlockSecurities(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает период, в течение которого может быть исполнена сделка.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>0 - немедленно, 1 - сессионно, 2 - бессрочно.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_PERIOD")]
    public static partial int TradePeriod(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает дату и время заключения сделки в формате FILETIME.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>FILETIME (UTC).</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_FILETIME")]
    public static partial long TradeFileTime(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает компонент даты/времени сделки в зависимости от <paramref name="timeType"/>.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <param name="timeType">0 - дата (YYYYMMDD), 1 - время (HHMMSS), 2 - микросекунды (0–999999).</param>
    /// <returns>Запрошенный компонент даты/времени.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_DATE_TIME")]
    public static partial int TradeDateTime(IntPtr tradeDescriptor, int timeType);

    /// <summary>
    /// Возвращает вид сделки.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>1 - обычная, 2 - адресная, 3 - адресная с контрагентом, 4 - перенос / своп, 5 - РЕПО без цены, 6 - РЕПО по цене выкупа, 7 - РЕПО по цене сделки, 8 - внебиржевая адресная сделка, 9 - внебиржевая безадресная сделка.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_KIND")]
    public static partial int TradeKind(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает комиссию брокера по сделке.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Размер комиссии.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_BROKER_COMMISSION")]
    public static partial double TradeBrokerCommission(IntPtr tradeDescriptor);

    /// <summary>
    /// Возвращает TRANS_ID транзакции, породившей сделку.
    /// </summary>
    /// <param name="tradeDescriptor">Дескриптор сделки из callback TRANS2QUIK.</param>
    /// <returns>Идентификатор транзакции.</returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRADE_TRANSID")]
    public static partial int TradeTransId(IntPtr tradeDescriptor);
}
