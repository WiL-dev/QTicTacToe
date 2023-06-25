using System.Collections.Concurrent;

namespace QTicTacToe.Api.SSE.Services;

public class ServerSentEventsService : IServerSentEventsService
{
    private readonly ConcurrentDictionary<string, ServerSentEventsClient> _clients = new ConcurrentDictionary<string, ServerSentEventsClient>();

    public void AddClient(ServerSentEventsClient client, string clientId)
    {
        _clients.TryAdd(clientId, client);
    }

    public void RemoveClient(string clientId)
    {
        ServerSentEventsClient? client;
        _clients.TryRemove(clientId, out client);
    }

    public void sendEvent(string clientId) {
        ServerSentEventsClient? client;
        _clients.TryGetValue(clientId, out client);

        if (client is not null)
        {
            client.SendEventAsync();
        } else
        // TODO: Handle the missing client warning better
        {
            System.Console.WriteLine($"No client created with id {clientId}");
        }
    }
}