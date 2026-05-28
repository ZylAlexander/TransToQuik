using System.Text;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions.KillTransaction;

public abstract class QuikKillOrderTransactionBase : QuikTransaction
{
    /// <summary>
    /// Уникальный номер заявки, снимаемой из торговой системы. Применяется при «ACTION» = «KILL_ORDER» или «ACTION» = «KILL_NEG_DEAL» или «ACTION» = «KILL_QUOTE»
    /// </summary>
    public required ulong OrderKey { get; set; }
    protected override void AppendBody(StringBuilder sb)
    {
        sb.AppendIfNotEmpty("ORDER_KEY", OrderKey.ToString());
    }
    protected override ValidationResult ValidateSelf()
    {
        if (OrderKey <= 0)
        {
            return ValidationResult.Failure("QuikKillOrder: OrderKey must be greater than 0");
        }

        return ValidationResult.Success();
    }
}

