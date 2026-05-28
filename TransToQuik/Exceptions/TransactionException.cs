using System;

namespace TransToQuik.Exceptions;

public class TransactionException : Exception
{
    public TransactionException(string message)
    : base(message)
    { }

}