using System;
using System.Runtime.InteropServices;

namespace TransToQuik.Interop;

public delegate void ConnectionStatusCallback(int ConnectionEvent, int ExtendedErrorCode, string InfoMessage);

internal static partial class QuikNativeApi
{
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_CONNECT")]
    public static partial int Connect(
        [MarshalAs(UnmanagedType.LPStr)] string pathToInfo,
        out int extendedErrorCode,
        byte[] errorMessage,
        uint errorMessageSize);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_DISCONNECT")]
    public static partial int Disconnect(
        out int extendedErrorCode,
        byte[] errorMessage,
        uint errorMessageSize);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_IS_QUIK_CONNECTED")]
    public static partial int IsQuikConnected(
        out int extendedErrorCode,
        byte[] errorMessage,
        uint errorMessageSize);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_IS_DLL_CONNECTED")]
    public static partial int IsDllConnected(
        out int extendedErrorCode,
        byte[] errorMessage,
        uint errorMessageSize);

    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_SET_CONNECTION_STATUS_CALLBACK")]
    public static partial int SetConnectionStatusCallback(
        ConnectionStatusCallback connectionStatusCallback,
        out int extendedErrorCode,
        byte[] errorMessage,
        uint errorMessageSize);
}
