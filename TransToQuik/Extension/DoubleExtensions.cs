using System.Globalization;

namespace TransToQuik.Extension;

public static class DoubleExtensions
{
    /// <summary>
    /// Форматирует цену для параметров транзакции (PRICE, STOPPRICE и т.д.).
    /// Число знаков после запятой должно совпадать с полем <c>scale</c> инструмента в QUIK
    /// (см. <c>getSecurityInfo</c> / <c>SEC_SCALE</c>). Если <paramref name="priceScale"/> не задан — 2 знака.
    /// </summary>
    public static string AsQuikPriceString(this double value, int? priceScale) =>
        QuikPriceFormatter.Format(value, priceScale);

    public static string AsQuikString(this double value, int? priceScale = null, string format = "F2") =>
        priceScale.HasValue
            ? value.AsQuikPriceString(priceScale)
            : value.ToString(format, CultureInfo.InvariantCulture);
}

/// <summary>
/// Форматирование цен для строки транзакции TRANS2QUIK.
/// </summary>
public static class QuikPriceFormatter
{
    public const int DefaultPriceScale = 2;

    public static string Format(double value, int? priceScale)
    {
        var scale = priceScale ?? DefaultPriceScale;
        if (scale <= 0)
        {
            return value.ToString("F0", CultureInfo.InvariantCulture);
        }

        return value.ToString($"F{scale}", CultureInfo.InvariantCulture);
    }
}