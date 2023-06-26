using QTicTacToe.Api.Models;
using QTicTacToe.Api.SSE.Helpers;

namespace QTicTacToe.Api.SSE.Models;

public class ServerSentEventsClient
{
    private readonly HttpResponse _response;

    public ServerSentEventsClient(HttpResponse response)
    {
        _response = response;
    }

    public void SendEventMove(MoveOutput move) {
        _response.WriteSseMove(move);
    }

    public void SendEvent() {
        _response.WriteSseTest();
    }
}