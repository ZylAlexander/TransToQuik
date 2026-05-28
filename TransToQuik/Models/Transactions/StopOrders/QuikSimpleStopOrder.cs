using TransToQuik.Enums;

namespace TransToQuik.Models.Transactions;

public class QuikSimpleStopOrder : QuikStopOrder
{
    public override QuikStopOrderKind StopOrderKind => QuikStopOrderKind.SimpleStopOrder;
}
