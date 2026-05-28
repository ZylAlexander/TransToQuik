using System;

namespace TransToQuik.Interfaces;

public interface IQuikTransactionInfoApi
{
    string ClassCode(IntPtr replyDescriptor);
    string SecCode(IntPtr replyDescriptor);
    double Price(IntPtr replyDescriptor);
    long Quantity(IntPtr replyDescriptor);
    long Balance(IntPtr replyDescriptor);
    string FirmId(IntPtr replyDescriptor);
    string Account(IntPtr replyDescriptor);
    string ClientCode(IntPtr replyDescriptor);
    string BrokerRef(IntPtr replyDescriptor);
    string ExchangeCode(IntPtr replyDescriptor);
    short TransactionReplyOrdersCount(IntPtr tradeDescriptor);
    int TransactionReplyFirstOrderNumberById(IntPtr tradeDescriptor, int orderId);
    int TransactionReplyOrderNumberById(IntPtr tradeDescriptor, int orderId);
    double TransactionReplyPriceById(IntPtr tradeDescriptor, int orderId);
    long TransactionReplyQuantityById(IntPtr tradeDescriptor, int orderId);
    long TransactionReplyBalanceById(IntPtr tradeDescriptor, int orderId);
    string TransactionReplyFirmidById(IntPtr tradeDescriptor, int orderId);
    string TransactionReplyAccountById(IntPtr tradeDescriptor, int orderId);
    string TransactionReplyClientCodeById(IntPtr tradeDescriptor, int orderId);
    string TransactionReplyBrokerrefById(IntPtr tradeDescriptor, int orderId);
}
