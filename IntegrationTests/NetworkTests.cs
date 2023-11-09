using Configuration;

namespace IntegrationTests;

public class NetworkTests
{
    [Fact]
    public async Task TestClientServer()
    {
        var configuration = new Configuration.Configuration();
        using var server = new SocketServer.SocketServer(configuration, new NullLogger());
        using var client = new SocketClient.SocketClient(configuration);

        const string request = "test";
        const string expected = "tset";

        var stopServerToken = new CancellationTokenSource();
        var serverTask = server.ListenAndSendResponseAsync(
            req => new string(req.Reverse().ToArray()), 
            stopServerToken.Token);

        Assert.Equal(expected, await client.SendAndWaitForResponseAsync(request));

        stopServerToken.Cancel();
        //await serverTask;
    }
}

class NullLogger : ILogger
{
    /// <inheritdoc />
    public void LogMessage(string message)
    {
    }
}