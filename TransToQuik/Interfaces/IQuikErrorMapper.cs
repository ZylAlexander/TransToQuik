using System;
using TransToQuik.Enums;

namespace TransToQuik.Interfaces;

public interface IQuikErrorMapper<TError>
where TError : Enum
{
    TError MapError(QuikReturnStatus status);
    bool IsSuccess(QuikReturnStatus code);
}
