using Microsoft.AspNetCore.Mvc;
using QTicTacToe.Api.SSE.Services;
using QTicTacToe.Api.SSE.Models;

namespace QTicTacToe.Api.Controllers;

[ApiController]
public class ConnectionController : ControllerBase
{
    private readonly IServerSentEventsService _serverSentEventsSevice;

    public ConnectionController(IServerSentEventsService serverSentEventsSevice)
    {
        _serverSentEventsSevice = serverSentEventsSevice;
    }

    [HttpGet("connect")]
    public async void SeeConnect(string client_id) {
        HttpContext.Response.ContentType = "text/event-stream";
        HttpContext.Response.Headers.Add("Connection", "keep-alive");
        HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
        await HttpContext.Response.Body.FlushAsync();

        ServerSentEventsClient seeClient = new ServerSentEventsClient(HttpContext.Response);
        _serverSentEventsSevice.AddClient(seeClient, client_id);

        HttpContext.RequestAborted.WaitHandle.WaitOne();

        _serverSentEventsSevice.RemoveClient(client_id);
    }
}