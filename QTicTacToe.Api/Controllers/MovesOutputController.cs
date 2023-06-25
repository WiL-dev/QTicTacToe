using Microsoft.AspNetCore.Mvc;
using QTicTacToe.Api.SSE.Services;
using QTicTacToe.Api.SSE;

namespace QTicTacToe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovesOutputController : ControllerBase
{
    private readonly IServerSentEventsService _serverSentEventsSevice;

    public MovesOutputController(IServerSentEventsService serverSentEventsSevice)
    {
        _serverSentEventsSevice = serverSentEventsSevice;
    }

    [HttpGet("/connect")]
    public async Task SeeConnect(string client_id) {
        HttpContext.Response.ContentType = "text/event-stream";
        HttpContext.Response.Headers.Add("Connection", "keep-alive");
        HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
        HttpContext.Response.Headers.Add("Access-Control-Allow-origin", "http://localhost:8000");
        await HttpContext.Response.Body.FlushAsync();

        ServerSentEventsClient seeClient = new ServerSentEventsClient(HttpContext.Response);
        _serverSentEventsSevice.AddClient(seeClient, client_id);

        HttpContext.RequestAborted.WaitHandle.WaitOne();

        _serverSentEventsSevice.RemoveClient(client_id);
    }
}