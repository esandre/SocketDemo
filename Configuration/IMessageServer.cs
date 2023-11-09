namespace Configuration;

public interface IMessageServer
{
    Task ListenAndSendResponseAsync(Func<string, string> whatToDoOnRequest, CancellationToken token);
}