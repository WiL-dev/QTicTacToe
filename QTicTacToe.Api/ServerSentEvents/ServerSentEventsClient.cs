using QTicTacToe.Api.Models;
using QTicTacToe.Api.SSE.Helpers;

namespace QTicTacToe.Api.SSE;

public class ServerSentEventsClient
{
    private readonly HttpResponse _response;

    public ServerSentEventsClient(HttpResponse response)
    {
        _response = response;
    }

    public void SendEventMoveAsync(MoveOutput move) {
        _response.WriteSseMove(move);
    }

    public void SendEventAsync() {
        _response.WriteSseTest();
    }
}