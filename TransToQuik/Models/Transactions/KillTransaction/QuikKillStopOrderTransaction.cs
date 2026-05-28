using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions.KillTransaction;

public class QuikKillStopOrderTransaction : QuikTransaction
{
    /// <summary>
    /// Номер стоп-заявки, снимаемой из торговой системы. Применяется толькопри «ACTION» = «KILL_STOP_ORDER»
    /// </summary>
    public required uint StopOrderKey { get; set; }
    public override QuikAction Action => QuikAction.KillStopOrder;
    protected override void AppendBody(StringBuilder sb)
    {
        sb.AppendIfNotEmpty("STOP_ORDER_KEY", StopOrderKey.ToString());
    }
    protected override ValidationResult ValidateSelf()
    {
        if (StopOrderKey <= 0)
        {
            return ValidationResult.Failure("QuikKillOrder: StopOrderKey must be greater than 0");
        }

        return ValidationResult.Success();
    }
}

