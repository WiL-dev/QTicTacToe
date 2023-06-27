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
    public ActionResult<MoveOutput> ReceiveMove(string client_id, [FromBody]MoveInput move)
    {
        // TODO: Respond before sending events
        return _serverSentEventsService.ReceiveMove(client_id, move);
    }
}