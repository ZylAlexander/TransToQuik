using TransToQuik.Enums;

namespace TransToQuik.Models.Transactions.KillTransaction;

public class QuikKillQuoteTransaction : QuikKillOrderTransactionBase
{
    public override QuikAction Action => QuikAction.KillQuote;
}

