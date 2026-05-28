using System;
using TransToQuik.Enums;

namespace TransToQuik.Models;

public readonly record struct QuikResult<TError>
where TError : Enum
{
    public QuikReturnStatus Code { get; }
    public bool Success { get; }
    public int? ExtendedErrorCode { get; }
    public string Message { get; }
    public TError ErrorKind { get; }

    internal QuikResult(bool success, QuikReturnStatus code, int? extendedErrorCode, string message, TError errorKind)
    {
        Success = success;
        Code = code;
        ExtendedErrorCode = extendedErrorCode;
        Message = message;
        ErrorKind = errorKind;
    }
}
