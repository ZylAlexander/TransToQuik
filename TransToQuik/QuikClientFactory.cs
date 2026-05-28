using TransToQuik.Interfaces;

namespace TransToQuik;

public static class QuikClientFactory
{
    public static IQuikClient CreateClient()
    {
        var connection = QuikConnection.Instance;

        return new QuikClient(
            connection,
            QuikNativeWrapper.DefaultInstance,
            new(
                QuikNativeWrapper.DefaultInstance,
                QuikNativeWrapper.DefaultInstance,
                QuikNativeWrapper.DefaultInstance));
    }
}
