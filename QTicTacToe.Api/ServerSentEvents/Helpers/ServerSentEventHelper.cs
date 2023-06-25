using QTicTacToe.Api.Models;

namespace QTicTacToe.Api.SSE.Helpers;

public static class ServerSentEventHelper
{
    public static void WriteSseMove(this HttpResponse response, MoveOutput move)
    {
        response.WriteSseField("Id", "random");
        response.WriteSseField("event", "random");
        response.WriteSseField("data", $"x is {move.X}");
        response.WriteSseField("data", $"y is {move.Y}");
        response.WriteSseField("data", $"z is {move.Z}");
        response.WriteSseField("data", $"is winner? {move.IsWinner}");
        response.WriteSseBlockEnding();
    }

    public static void WriteSseTest(this HttpResponse response)
    {
        response.WriteSseField("id", "random");
        response.WriteSseField("event", "random");
        response.WriteSseField("data", "x is move.X");
        response.WriteSseField("data", "y is move.Y");
        response.WriteSseField("data", "z is move.Z");
        response.WriteSseField("data", "is winner? move.IsWinner");
        response.WriteSseBlockEnding();
    }

    private static async void WriteSseField(this HttpResponse response, string field, string data)
    {
        await response.WriteAsync($"{field}: {data}\n");
    }

    private static async void WriteSseBlockEnding(this HttpResponse response)
    {
        await response.WriteAsync("\n");
        await response.Body.FlushAsync();
    }
}