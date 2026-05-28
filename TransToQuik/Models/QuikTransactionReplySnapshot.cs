namespace TransToQuik.Models;

/// <summary>
/// Поля ответа на транзакцию, снятые в потоке callback (дескриптор QUIK после callback недействителен).
/// </summary>
public readonly record struct QuikTransactionReplySnapshot(
    string ClassCode,
    string SecCode,
    string Account,
    string FirmId,
    string ClientCode,
    string BrokerRef,
    string ExchangeCode,
    double Price,
    long Quantity,
    long Balance)
{
    public static QuikTransactionReplySnapshot Empty => default;
}
