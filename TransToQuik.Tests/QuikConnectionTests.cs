using Moq;
using TransToQuik.Enums;
using TransToQuik.Interfaces;
using TransToQuik.Interop;
using Xunit;

namespace TransToQuik.Tests;

public class QuikConnectionTests
{
    private readonly Mock<IQuikConnectionApi> _mockApi;
    private readonly QuikConnection _connection;

    public QuikConnectionTests()
    {
        _mockApi = new Mock<IQuikConnectionApi>();
        _connection = new QuikConnection(_mockApi.Object);
    }

    [Fact]
    public void Path_ShouldReturnProvidedPath_WhenConnected()
    {
        // Arrange
        var path = "C:\\Quik";

        _mockApi.Setup(x => x.Connect(It.IsAny<string>(), out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns(0);

        // Act
        _connection.Connect(path);
        var result = _connection.Path;

        // Assert
        Assert.Equal(path, result);
    }

    [Theory]
    [InlineData(QuikReturnStatus.QuikConnected, QuikConnectionStatus.Connected)]
    [InlineData(QuikReturnStatus.QuikNotConnected, QuikConnectionStatus.QuikNotConnected)]
    [InlineData(QuikReturnStatus.DllNotConnected, QuikConnectionStatus.DllNotConnected)]
    public void Status_ShouldMapReturnStatusCorrectly(QuikReturnStatus returnStatus, QuikConnectionStatus expected)
    {
        // Arrange
        _mockApi.Setup(x => x.IsQuikConnected(out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns((out int code, byte[] _, uint _) =>
                {
                    code = 0;
                    return (int)returnStatus;
                });

        // Act
        var result = _connection.Status;

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Connected_ShouldReturnTrue_WhenStatusIsConnected()
    {
        // Arrange
        _mockApi.Setup(x => x.IsQuikConnected(out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns((out int code, byte[] _, uint _) =>
                {
                    code = 0;
                    return (int)QuikReturnStatus.QuikConnected;
                });

        // Act
        var result = _connection.Connected;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DLLConnected_ShouldReturnTrue_WhenDllStatusIsConnected()
    {
        // Arrange
        _mockApi.Setup(x => x.IsDllConnected(out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns((out int code, byte[] _, uint _) =>
                {
                    code = 0;
                    return (int)QuikReturnStatus.DllConnected;
                });

        // Act
        var result = _connection.DLLConnected;

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(QuikReturnStatus.QuikConnected, ConnectionAvailability.Connected)]
    [InlineData(QuikReturnStatus.QuikNotConnected, ConnectionAvailability.NotConnected)]
    [InlineData(QuikReturnStatus.DllNotConnected, ConnectionAvailability.Unknown)]
    public void Availability_ShouldMapCorrectly(QuikReturnStatus status, ConnectionAvailability expected)
    {
        // Arrange
        _mockApi.Setup(x => x.IsQuikConnected(out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns((out int code, byte[] _, uint _) =>
                {
                    code = 0;
                    return (int)status;
                });

        // Act
        var availability = _connection.Availability;

        // Assert
        Assert.Equal(expected, availability);
    }

    [Fact]
    public void Connect_ShouldReturnQuikResult()
    {
        // Arrange
        const string path = "C:\\Quik";
        const int expectedCode = 0;

        _mockApi.Setup(x => x.Connect(It.IsAny<string>(), out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns(expectedCode);

        // Act
        var result = _connection.Connect(path);

        // Assert
        Assert.Equal(expectedCode, (int)result.Code);
    }

    [Fact]
    public void Disconnect_ShouldReturnQuikResult()
    {
        // Arrange
        const int expectedCode = 0;

        _mockApi.Setup(x => x.Disconnect(out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns(expectedCode);

        // Act
        var result = _connection.Disconnect();

        // Assert
        Assert.Equal(expectedCode, (int)result.Code);
    }

    [Fact]
    public void RegisterStatusCallback_ShouldReturnQuikResult()
    {
        // Arrange
        const int expectedCode = 0;

        _mockApi.Setup(x => x.SetConnectionStatusCallback(It.IsAny<ConnectionStatusCallback>(), out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns(expectedCode);

        // Act
        var result = _connection.RegisterStatusCallback((connectionEvent, extendedErrorCode, infoMessage) => { });

        // Assert
        Assert.Equal(expectedCode, (int)result.Code);
    }

    [Fact]
    public void Dispose_ShouldCallDisconnect()
    {
        // Arrange
        _mockApi.Setup(x => x.Disconnect(out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()))
                .Returns(0)
                .Verifiable();

        // Act
        _connection.Dispose();

        // Assert
        _mockApi.Verify(x => x.Disconnect(out It.Ref<int>.IsAny, It.IsAny<byte[]>(), It.IsAny<uint>()), Times.Once);
    }
}
