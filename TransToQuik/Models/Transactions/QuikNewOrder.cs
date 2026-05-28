using TransToQuik.Enums;

namespace TransToQuik.Models.Transactions;

public class QuikNewOrder : QuikOrderTransaction
{
    public override QuikAction Action => QuikAction.NewOrder;
}
