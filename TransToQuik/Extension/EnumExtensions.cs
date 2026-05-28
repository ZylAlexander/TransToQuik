using System;
using System.Numerics;

namespace TransToQuik.Extension;

public static class EnumExtensions
{
    public static T GetValueOrDefault<T, TNumber>(TNumber value, T defaultValue)
    where T : Enum
    where TNumber : INumber<TNumber> =>
        Enum.IsDefined(typeof(T), value)
        ? (T)Enum.ToObject(typeof(T), value)
        : defaultValue;

}