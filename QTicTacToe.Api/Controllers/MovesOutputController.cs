using Microsoft.AspNetCore.Mvc;

namespace QTicTacToe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovesOutputController : ControllerBase
{
    [HttpGet("/see")]
    public async Task SEE() {
        System.Console.WriteLine("SEE request");

        HttpContext.Response.Headers.Add("Access-Control-Allow-origin", "http://localhost:8000");
        HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
        HttpContext.Response.Headers.Add("Content-Type", "text/event-stream");
        await HttpContext.Response.Body.FlushAsync();

        await HttpContext.Response.WriteAsync("id: 1231\n");
        await HttpContext.Response.WriteAsync("event: event_name\n");
        await HttpContext.Response.WriteAsync($"data: Hi v1\n");
        await HttpContext.Response.WriteAsync("\n");
        await HttpContext.Response.Body.FlushAsync();

        HttpContext.RequestAborted.WaitHandle.WaitOne();

        System.Console.WriteLine("End");
    }
}