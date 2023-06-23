using System.Collections.Concurrent;

namespace QTicTacToe.Api.SSE.Services;

public class ServerSentEventsService
{
    private readonly ConcurrentDictionary<Guid, ServerSentEventsClient> _clients = new ConcurrentDictionary<Guid, ServerSentEventsClient>();

    public Guid AddClient(ServerSentEventsClient client)
    {
        Guid clientId = Guid.NewGuid();
        _clients.TryAdd(clientId, client);
        return clientId;
    }

    public void RemoveClient(Guid clientId)
    {
        ServerSentEventsClient? client;
        _clients.TryRemove(clientId, out client);
    }
}