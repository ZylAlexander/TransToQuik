using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikUnits
{
    [EnumMember(Value = "PERCENTS")]
    Percents,
    [EnumMember(Value = "PRICE_UNITS")]
    PriceUnits
}
