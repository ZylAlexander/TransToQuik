using TransToQuik.Interop;

namespace TransToQuik.Interfaces;

public interface IQuikConnectionApi
{
    int Connect(string PathToInfo, out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize);
    int Disconnect(out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize);
    int IsQuikConnected(out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize);
    int IsDllConnected(out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize);
    int SetConnectionStatusCallback(ConnectionStatusCallback ConnectionStatusCallback, out int ExtendedErrorCode, byte[] ErrorMessage, uint ErrorMessageSize);
}
