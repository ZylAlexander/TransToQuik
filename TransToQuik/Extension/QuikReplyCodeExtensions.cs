using TransToQuik.Enums;

namespace TransToQuik.Extension;

public static class QuikReplyCodeExtensions
{
    /// <summary>
    /// Пытается разобрать код ответа на транзакцию из TRANS2QUIK.
    /// </summary>
    public static bool TryParse(int rawReplyCode, out QuikReplyCode replyCode)
    {
        if (Enum.IsDefined(typeof(QuikReplyCode), rawReplyCode))
        {
            replyCode = (QuikReplyCode)rawReplyCode;
            return true;
        }

        replyCode = default;
        return false;
    }

    /// <summary>
    /// Транзакция считается успешно принятой/исполненной на стороне QUIK.
    /// Коды 0–1 - промежуточные статусы доставки, не подтверждение исполнения заявки.
    /// </summary>
    public static bool IsSuccessfulOutcome(this QuikReplyCode replyCode) =>
        replyCode switch
        {
            QuikReplyCode.Executed => true,
            QuikReplyCode.AcceptedAfterRestrictionViolation => true,
            _ => false,
        };
}
