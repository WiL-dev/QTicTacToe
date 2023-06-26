using Microsoft.AspNetCore.Mvc;
using QTicTacToe.Api.SSE.Services;
using QTicTacToe.Api.Models;

namespace QTicTacToe.Api.Controllers;

[ApiController]
public class MoveInputController : ControllerBase
{
    private readonly IServerSentEventsService _serverSentEventsService;

    public MoveInputController(IServerSentEventsService serverSentEventsService)
    {
        _serverSentEventsService = serverSentEventsService;
    }

    [HttpPost("move")]
    public IActionResult ReceiveMove(string client_id, [FromBody]MoveInput move)
    {
        System.Console.WriteLine(move.ToString());
        HttpContext.Response.Headers.Add("Cache-Control", "no-cache");

        _serverSentEventsService.sendEvent("123");

        return Ok(move);
    }
}