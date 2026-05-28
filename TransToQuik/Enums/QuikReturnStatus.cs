namespace TransToQuik.Enums;

public enum QuikReturnStatus
{
    Success,
    Failed,
    QuikTerminalNotFound,
    DllVersionNotSupported,
    DllAlreadyConnectedToQuik,
    WrongSyntax,
    QuikNotConnected,
    DllNotConnected,
    QuikConnected,
    QuikDisconnected,
    DllConnected,
    DllDisconnected,
    MemoryAllocationError,
    WrongConnectionHandle,
    WrongInputParams
}
