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

    public Task SendEventAsync(MoveOutput move) {
        return _response.WriteSseEventAsync(move);
    }
}