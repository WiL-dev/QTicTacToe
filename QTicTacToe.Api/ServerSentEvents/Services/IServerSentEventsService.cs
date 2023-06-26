using QTicTacToe.Api.SSE.Models;

namespace QTicTacToe.Api.SSE.Services;

public interface IServerSentEventsService
{
    void AddClient(ServerSentEventsClient client, string clientId);

    void RemoveClient(string clientId);

    void sendEvent(string clientId);
}