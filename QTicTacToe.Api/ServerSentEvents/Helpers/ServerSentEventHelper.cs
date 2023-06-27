using QTicTacToe.Api.Models;

namespace QTicTacToe.Api.SSE.Helpers;

public static class ServerSentEventHelper
{
    public static void WriteSseMove(this HttpResponse response, MoveOutput move)
    {
        // response.WriteSseField("Id", "random");
        response.WriteSseField("event", "move_placed");
        response.WriteSseField("data", $"isValid is {move.isValid}");
        response.WriteSseField("data", $"is winner? {move.IsWinner}");
        response.WriteSseBlockEnding();
    }

    private static async void WriteSseField(this HttpResponse response, string field, string data)
    {
        // Console.WriteLine("Waiting...");
        // Thread.Sleep(6000);
        // Console.WriteLine("Ok");
        await response.WriteAsync($"{field}: {data}\n");
    }

    private static async void WriteSseBlockEnding(this HttpResponse response)
    {
        await response.WriteAsync("\n");
        await response.Body.FlushAsync();
    }
}