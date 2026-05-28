using System;
using TransToQuik.Models;

namespace TransToQuik.Extension
{
    public static class QuikOrderExtensions
    {
        /// <summary>
        /// Возвращает количество заявки
        /// </summary>
        public static long OrderQty(this QuikOrder order) => order.Details.OrderQty;

        /// <summary>
        /// Возвращает дату заявки
        /// </summary>
        public static int OrderDate(this QuikOrder order) => order.Details.OrderDate;

        /// <summary>
        /// Возвращает время заявки
        /// </summary>
        public static int OrderTime(this QuikOrder order) => order.Details.OrderTime;
        /// <summary>
        /// Возвращает время активации заявки
        /// </summary>
        public static int OrderActivationTime(this QuikOrder order) => order.Details.OrderActivationTime;

        /// <summary>
        /// Возвращает время снятия заявки
        /// </summary>
        public static int OrderWithdrawTime(this QuikOrder order) => order.Details.OrderWithdrawTime;

        /// <summary>
        /// Возвращает дату окончания срока действия заявки
        /// </summary>
        public static int OrderExpiry(this QuikOrder order) => order.Details.OrderExpiry;

        /// <summary>
        /// Возвращает накопленный купонный доход заявки
        /// </summary>
        public static double OrderAccruedInt(this QuikOrder order) => order.Details.OrderAccruedInt;

        /// <summary>
        /// Возвращает доходность заявки
        /// </summary>
        public static double OrderYield(this QuikOrder order) => order.Details.OrderYield;
        /// <summary>
        /// Возвращает строковый идентификатор трейдера, от имени которого отправлена заявка
        /// </summary>
        public static string OrderUserId(this QuikOrder order) => order.Details.OrderUserId;

        /// <summary>
        /// Возвращает UserID пользователя, указанный в заявке
        /// </summary>
        public static int OrderUID(this QuikOrder order) => order.Details.OrderUID;

        /// <summary>
        /// Возвращает торговый счет, указанный в заявке
        /// </summary>
        public static string OrderAccount(this QuikOrder order) => order.Details.OrderAccount;

        /// <summary>
        /// Возвращает комментарий заявки
        /// </summary>
        public static string OrderBrokerRef(this QuikOrder order) => order.Details.OrderBrokerRef;

        /// <summary>
        /// Возвращает код клиента, отправившего заявку
        /// </summary>
        public static string OrderClientCode(this QuikOrder order) => order.Details.OrderClientCode;
        /// <summary>
        /// Возвращает строковый идентификатор организации пользователя, отправившего заявку
        /// </summary>
        public static string OrderFirmId(this QuikOrder order) => order.Details.OrderFirmId;

        /// <summary>
        /// Возвращает видимое количество для заявок типа «Айсберг»
        /// </summary>
        public static long OrderVisibleQTY(this QuikOrder order) => order.Details.OrderVisibleQty;

        /// <summary>
        /// Возвращает период, когда была выставлена заявка, возможные значения: «0» - «Открытие», «1» - «Нормальный», «2» - «Закрытие»
        /// </summary>
        public static int OrderPeriod(this QuikOrder order) => order.Details.OrderPeriod;

        /// <summary>
        /// Возвращает дату и время выставления заявки в формате YY.MM.DD HH:MM:SS.MS
        /// </summary>
        public static DateTime OrderFileTime(this QuikOrder order) => order.Details.OrderFileTime;

        /// <summary>
        /// Возвращает дату и время снятия заявки в формате YY.MM.DD HH:MM:SS.MS
        /// </summary>
        public static DateTime OrderWithdrawFileTime(this QuikOrder order) => order.Details.OrderWithdrawFileTime;
        /// <summary>
        /// Возвращает временные параметры заявки в зависимости от значения параметра TimeType. 
        /// Параметр TimeType может принимать следующие значения:
        /// «0» – функция возвращает дату выставления заявки в формате YYYYMMDD,
        /// «1» – функция возвращает время выставления заявки в формате HHMMSS,
        /// «2» – функция возвращает микросекунды времени выставления заявки, целое число от 0 до 999999,
        /// «3» – функция возвращает дату снятия заявки в формате YYYYMMDD,
        /// «4» – функция возвращает время снятия заявки в формате HHMMSS,
        /// «5» – функция возвращает микросекунды времени снятия заявки, целое число от 0 до 999999
        /// </summary>
        public static int OrderDateTime(this QuikOrder order, int timeType) =>
            timeType switch
            {
                0 => order.Details.OrderDatePlaced,
                1 => order.Details.OrderTimePlaced,
                2 => order.Details.OrderMicrosecondsPlaced,
                3 => order.Details.OrderDateWithdrawn,
                4 => order.Details.OrderTimeWithdrawn,
                5 => order.Details.OrderMicrosecondsWithdrawn,
                _ => throw new ArgumentOutOfRangeException(nameof(timeType), timeType, "TimeType must be 0..5.")
            };

        /// <summary>
        /// Возвращает способ указания объема заявки; возможные значения: «0» – не определен, «1» – количество, «2» – объем
        /// </summary>
        public static int OrderValueEntryType(this QuikOrder order) => order.Details.OrderValueEntryType;

        /// <summary>
        /// Возвращает расширенные флаги заявки
        /// </summary>
        public static int OrderExtendedFlags(this QuikOrder order) => order.Details.OrderExtendedFlags;

        /// <summary>
        /// Возвращает минимально допустимое количество; «0» – ограничение не задано
        /// </summary>
        public static int OrderMinQTY(this QuikOrder order) => order.Details.OrderMinQty;

        /// <summary>
        /// Возвращает тип исполнения заявки; «0» – значение не задано
        /// </summary>
        public static int OrderExecType(this QuikOrder order) => order.Details.OrderExecType;
        /// <summary>
        /// Возвращает среднюю цену приобретения при частичном исполнении заявки
        /// </summary>
        public static double OrderAwgPrice(this QuikOrder order) => order.Details.OrderAwgPrice;

        /// <summary>
        /// Возвращает причину отклонения заявки брокером
        /// </summary>
        public static string OrderRejectReason(this QuikOrder order) => order.Details.OrderRejectReason;
    }

}
