using TransToQuik.Models;

namespace TransToQuik.Extension;

public static class QuikAsyncTransactionResultExtensions
{
    /// <summary>
    /// Код инструмента из снимка ответа (снят в callback).
    /// </summary>
    public static string SecCode(this QuikAsyncTransactionResult result) => result.Reply.SecCode;

    /// <summary>
    /// Код класса из снимка ответа (снят в callback).
    /// </summary>
    public static string ClassCode(this QuikAsyncTransactionResult result) => result.Reply.ClassCode;

    /// <summary>
    /// Торговый счёт из снимка ответа (снят в callback).
    /// </summary>
    public static string Account(this QuikAsyncTransactionResult result) => result.Reply.Account;

    /// <summary>
    /// Код фирмы из снимка ответа (снят в callback).
    /// </summary>
    public static string FirmId(this QuikAsyncTransactionResult result) => result.Reply.FirmId;

    /// <summary>
    /// Код клиента из снимка ответа (снят в callback).
    /// </summary>
    public static string ClientCode(this QuikAsyncTransactionResult result) => result.Reply.ClientCode;

    /// <summary>
    /// Комментарий (BROKERREF) из снимка ответа (снят в callback).
    /// </summary>
    public static string BrokerRef(this QuikAsyncTransactionResult result) => result.Reply.BrokerRef;

    /// <summary>
    /// Биржевой код из снимка ответа (снят в callback).
    /// </summary>
    public static string ExchangeCode(this QuikAsyncTransactionResult result) => result.Reply.ExchangeCode;

    /// <summary>
    /// Цена из снимка ответа (снята в callback).
    /// </summary>
    public static double Price(this QuikAsyncTransactionResult result) => result.Reply.Price;

    /// <summary>
    /// Количество из снимка ответа (снято в callback).
    /// </summary>
    public static long Quantity(this QuikAsyncTransactionResult result) => result.Reply.Quantity;

    /// <summary>
    /// Остаток из снимка ответа (снят в callback).
    /// </summary>
    public static long Balance(this QuikAsyncTransactionResult result) => result.Reply.Balance;
}
