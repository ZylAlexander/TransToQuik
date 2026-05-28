namespace TransToQuik.Enums;

public enum QuikReplyCode
{
    /// <summary>
    /// Транзакция отправлена серверу.
    /// </summary>
    SentToServer = 0,

    /// <summary>
    /// Транзакция получена на сервер QUIK от клиента.
    /// </summary>
    ReceivedByServer = 1,

    /// <summary>
    /// Ошибка при передаче транзакции в торговую систему, отсутствует подключение шлюза Московской Биржи, повторно транзакция не отправляется.
    /// </summary>
    GatewayConnectionError = 2,

    /// <summary>
    /// Транзакция выполнена.
    /// </summary>
    Executed = 3,

    /// <summary>
    /// Транзакция не выполнена торговой системой, код ошибки будет указан в поле DESCRIPTION.
    /// </summary>
    NotExecutedBySystem = 4,

    /// <summary>
    /// Транзакция не прошла проверку сервера QUIK по каким-либо критериям (например, отсутствие прав).
    /// </summary>
    ServerValidationFailed = 5,

    /// <summary>
    /// Транзакция не прошла проверку лимитов сервера QUIK.
    /// </summary>
    LimitCheckFailed = 6,

    /// <summary>
    /// Транзакция не поддерживается торговой системой (например, попытка отправить ACTION = MOVE_ORDERS на Московской Бирже).
    /// </summary>
    NotSupportedBySystem = 10,

    /// <summary>
    /// Транзакция не прошла проверку правильности электронной подписи.
    /// </summary>
    SignatureValidationFailed = 11,

    /// <summary>
    /// Не удалось дождаться ответа на транзакцию, истек таймаут ожидания.
    /// </summary>
    Timeout = 12,

    /// <summary>
    /// Транзакция отвергнута, выполнение могло привести к кросс-сделке.
    /// </summary>
    CrossTradeRejected = 13,

    /// <summary>
    /// Транзакция не прошла контроль дополнительных ограничений.
    /// </summary>
    AdditionalRestrictionsFailed = 14,

    /// <summary>
    /// Транзакция принята после нарушения дополнительных ограничений.
    /// </summary>
    AcceptedAfterRestrictionViolation = 15,

    /// <summary>
    /// Транзакция отменена пользователем в ходе проверки дополнительных ограничений.
    /// </summary>
    CancelledByUserDuringRestrictionCheck = 16
}