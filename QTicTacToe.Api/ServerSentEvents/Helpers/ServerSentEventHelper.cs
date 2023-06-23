using QTicTacToe.Api.Models;

namespace QTicTacToe.Api.SSE.Helpers;

public static class ServerSentEventHelper
{
    public static async Task WriteSseEventAsync(this HttpResponse response, MoveOutput move)
    {
        await response.WriteSseField("Id", "random");
        await response.WriteSseField("event", "random");
        await response.WriteSseField("X", $"x is {move.X}");
        await response.WriteSseField("Y", $"y is {move.Y}");
        await response.WriteSseField("Z", $"z is {move.Z}");
        await response.WriteSseField("IsWinner", $"is winner? {move.IsWinner}");
        await response.WriteSseBlockEnding();
    }

    public static Task WriteSseField(this HttpResponse response, string field, string data)
    {
        return response.WriteAsync($"{field}: {data}\n");
    }

    public static Task WriteSseBlockEnding(this HttpResponse response)
    {
        return response.WriteAsync("\n");
    }
}