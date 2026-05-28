using TransToQuik.Enums;

namespace TransToQuik.Models.Transactions.KillTransaction;

public class QuikKillNegDealTransaction : QuikKillOrderTransactionBase
{
    public override QuikAction Action => QuikAction.KillNegDeal;
}

