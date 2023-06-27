using QTicTacToe.Api.SSE.Models;
using QTicTacToe.Api.Models;

namespace QTicTacToe.Api.SSE.Services;

public interface IServerSentEventsService
{
    void AddClient(ServerSentEventsClient client, string clientId);

    void RemoveClient(string clientId);

    void ReceiveMove(string clientId, MoveInput moveInput);
}