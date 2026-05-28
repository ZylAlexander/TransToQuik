using System;
using TransToQuik.Enums;
using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransToQuik;

internal static class QuikResultFactory
{
  public static QuikResult<TError> From<TError>(int rawCode, int extCode, string message, IQuikErrorMapper<TError> mapper)
    where TError : Enum
  {
    if (!Enum.IsDefined(typeof(QuikReturnStatus), rawCode))
    {
      return new QuikResult<TError>(
        success: false,
        code: QuikReturnStatus.Failed,
        extendedErrorCode: extCode == 0 ? null : extCode,
        message: string.IsNullOrWhiteSpace(message)
          ? $"Unknown QUIK return code: {rawCode}"
          : $"{message} (unknown return code: {rawCode})",
        errorKind: mapper.MapError(QuikReturnStatus.Failed));
    }

    var code = (QuikReturnStatus)rawCode;
    var success = mapper.IsSuccess(code);
    var error = mapper.MapError(code);
    int? extended = extCode == 0 ? null : extCode;

    return new QuikResult<TError>(success, code, extended, message, error);
  }
}
