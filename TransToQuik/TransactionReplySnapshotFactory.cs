using System;
using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransToQuik;

internal static class TransactionReplySnapshotFactory
{
    public static QuikTransactionReplySnapshot Capture(IQuikTransactionInfoApi api, IntPtr replyDescriptor)
    {
        if (replyDescriptor == IntPtr.Zero)
        {
            return QuikTransactionReplySnapshot.Empty;
        }

        return new QuikTransactionReplySnapshot(
            api.ClassCode(replyDescriptor),
            api.SecCode(replyDescriptor),
            api.Account(replyDescriptor),
            api.FirmId(replyDescriptor),
            api.ClientCode(replyDescriptor),
            api.BrokerRef(replyDescriptor),
            api.ExchangeCode(replyDescriptor),
            api.Price(replyDescriptor),
            api.Quantity(replyDescriptor),
            api.Balance(replyDescriptor));
    }
}
