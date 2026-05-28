using TransToQuik.Enums;

namespace TransToQuik.Models.Transactions.KillTransaction;

public class QuikKillOrderTransaction : QuikKillOrderTransactionBase
{
    public override QuikAction Action => QuikAction.KillOrder;
}

