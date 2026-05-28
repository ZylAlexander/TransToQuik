using System;
using TransToQuik.Enums;
using TransToQuik.Extension;
using TransToQuik.Interfaces;
using TransToQuik.Interop;
using TransToQuik.Mappers;
using TransToQuik.Models;

namespace TransToQuik;

public class QuikConnection : IQuikConnection
{
    private delegate int ResolveStatusCallback(out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize);

    private static readonly Lazy<QuikConnection> _instance = new(() => new(QuikNativeWrapper.DefaultInstance));
    public static QuikConnection Instance => _instance.Value;

    private readonly uint _maxMessageSize = QuikConstants.MaxMessageSize;
    private readonly IQuikConnectionApi _connectionApi;
    private string _path;
    private bool _isConnectedToPath;

    public string Path => _path;
    public bool Connected => Status == QuikConnectionStatus.Connected;
    public QuikConnectionStatus Status => GetQuikConnectStatus();
    public bool DLLConnected => GetDllConnectStatus();

    public ConnectionAvailability Availability => GetQuikAvailability();

    internal QuikConnection(IQuikConnectionApi connectionApi)
    {
        _connectionApi = connectionApi ?? throw new ArgumentNullException(nameof(connectionApi));
    }

    public QuikResult<ConnectError> Connect(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        if (_isConnectedToPath && string.Equals(_path, path, StringComparison.OrdinalIgnoreCase))
        {
            return QuikResultFactory.From(
                (int)QuikReturnStatus.Success,
                0,
                string.Empty,
                ConnectMapper.Instance);
        }

        if (_isConnectedToPath && !string.Equals(_path, path, StringComparison.OrdinalIgnoreCase))
        {
            Disconnect();
        }

        _path = path;
        var errorMessage = new NativeBuffer(_maxMessageSize);
        var code = _connectionApi.Connect(_path, out var extendedErrorCode, errorMessage.Bytes, _maxMessageSize);

        var result = QuikResultFactory.From(code, extendedErrorCode, errorMessage.AsString(), ConnectMapper.Instance);
        _isConnectedToPath = result.Success || result.ErrorKind == ConnectError.AlreadyConnected;
        return result;
    }

    public QuikResult<DisconnectError> Disconnect()
    {
        var errorMessage = new NativeBuffer(_maxMessageSize);
        var result = QuikResultFactory.From(
            _connectionApi.Disconnect(out var extendedErrorCode, errorMessage.Bytes, _maxMessageSize),
            extendedErrorCode,
            errorMessage.AsString(),
            DisconnectMapper.Instance);
        _isConnectedToPath = false;
        return result;
    }

    public QuikResult<SimpleError> RegisterStatusCallback(ConnectionStatusCallback FuncConnectionStatusCallback)
    {
        var errorMessage = new NativeBuffer(_maxMessageSize);
        return QuikResultFactory.From(
            _connectionApi.SetConnectionStatusCallback(FuncConnectionStatusCallback, out var extendedErrorCode, errorMessage.Bytes, _maxMessageSize),
            extendedErrorCode,
            errorMessage.AsString(),
            SimpleMapper.Instance);
    }

    public void Dispose()
    {
        Disconnect();
    }

    private bool GetDllConnectStatus()
    {
        var status = Execute(_connectionApi.IsDllConnected);

        return status.Code == QuikReturnStatus.DllConnected;
    }

    private QuikConnectionStatus GetQuikConnectStatus()
    {
        var state = Execute(_connectionApi.IsQuikConnected);

        return state.Code switch
        {
            QuikReturnStatus.QuikConnected => QuikConnectionStatus.Connected,
            QuikReturnStatus.QuikNotConnected => QuikConnectionStatus.QuikNotConnected,
            QuikReturnStatus.DllNotConnected => QuikConnectionStatus.DllNotConnected,
            _ => throw new NotSupportedException($"{nameof(state.Code)}: {state.Status}")
        };
    }

    private QuikConnectionState Execute(ResolveStatusCallback callback)
    {
        var errorMessage = new NativeBuffer(_maxMessageSize);
        var code = callback(out var _, errorMessage.Bytes, _maxMessageSize);
        return new QuikConnectionState(code, errorMessage.AsString());
    }

    private ConnectionAvailability GetQuikAvailability() =>
        GetQuikConnectStatus() switch
        {
            QuikConnectionStatus.Connected => ConnectionAvailability.Connected,
            QuikConnectionStatus.QuikNotConnected => ConnectionAvailability.NotConnected,
            QuikConnectionStatus.DllNotConnected => ConnectionAvailability.Unknown,
            _ => throw new InvalidOperationException("Unknown status")
        };
}
