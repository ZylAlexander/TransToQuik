using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikForAccount
{
    [EnumMember(Value = "OWNOWN")]
    OwnOwn,
    [EnumMember(Value = "OWNCLI")]
    OwnCli,
    [EnumMember(Value = "OWNDUP")]
    OwnDup,
    [EnumMember(Value = "CLICLI")]
    CliCli
}
