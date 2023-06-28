using System.Collections.Concurrent;
using QTicTacToe.Api.Models;
using QTicTacToe.Api.SSE.Models;

namespace QTicTacToe.Api.SSE.Services;

public class ServerSentEventsService : IServerSentEventsService
{
    private readonly ConcurrentDictionary<string, ServerSentEventsClient> _clients = new ConcurrentDictionary<string, ServerSentEventsClient>();
    private readonly Board board = new Board();
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

    public MoveOutput ReceiveMove(string clientId, MoveInput moveInput) {
        MoveOutput moveOutput = board.MakeMove(moveInput);

        Task.Run(() => this.SendMove(clientId, moveOutput));

        return moveOutput;
    }

    private void SendMove(string clientId, MoveOutput move)
    {
        ServerSentEventsClient? client;
        _clients.TryGetValue(clientId, out client);

        if (client is not null)
        {
            client.SendEventMove(move);
        } else
        {
            _iLogger.LogError($"No client created with id {clientId}");
        }
    }

}