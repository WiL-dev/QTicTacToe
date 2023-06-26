using System.Collections.Concurrent;
using QTicTacToe.Api.SSE.Models;

namespace QTicTacToe.Api.SSE.Services;

public class ServerSentEventsService : IServerSentEventsService
{
    private readonly ConcurrentDictionary<string, ServerSentEventsClient> _clients = new ConcurrentDictionary<string, ServerSentEventsClient>();
    private readonly ILogger<ServerSentEventsService> _iLogger;

    public ServerSentEventsService(ILogger<ServerSentEventsService> iLogger)
    {
        _iLogger = iLogger;
    }

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
            client.SendEvent();
        } else
        {
            _iLogger.LogError($"No client created with id {clientId}");
        }
    }
}