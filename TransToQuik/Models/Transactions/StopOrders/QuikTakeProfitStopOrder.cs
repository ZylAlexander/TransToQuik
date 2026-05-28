using TransToQuik.Enums;

namespace TransToQuik.Models.Transactions;

public class QuikTakeProfitStopOrder : QuikTakeProfitStopOrderBase
{
    public override QuikStopOrderKind StopOrderKind => QuikStopOrderKind.TakeProfitStopOrder;
}
