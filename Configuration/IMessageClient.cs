namespace Configuration;

public interface IMessageClient
{
    Task<string> SendAndWaitForResponseAsync(string message);
}