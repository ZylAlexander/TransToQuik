using System;
using TransToQuik.Enums;
using TransToQuik.Interop;
using TransToQuik.Models;

namespace TransToQuik.Interfaces;

public interface IQuikConnection : IDisposable
{
    public string Path { get; }
    bool Connected { get; }
    bool DLLConnected { get; }
    QuikConnectionStatus Status { get; }
    ConnectionAvailability Availability { get; }
    QuikResult<ConnectError> Connect(string path);
    QuikResult<DisconnectError> Disconnect();
    QuikResult<SimpleError> RegisterStatusCallback(ConnectionStatusCallback FuncConnectionStatusCallback);
}
