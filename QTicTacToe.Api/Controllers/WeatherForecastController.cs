using Microsoft.AspNetCore.Mvc;
using QTicTacToe.Api.SSE.Services;

namespace QTicTacToe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IServerSentEventsService _serverSentEventsSevice;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IServerSentEventsService serverSentEventsSevice)
    {
        _logger = logger;
        _serverSentEventsSevice = serverSentEventsSevice;
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }

    [HttpGet(Name = "testMove")]
    public void TestMove()
    {
        _serverSentEventsSevice.sendEvent("123");
    }
}
