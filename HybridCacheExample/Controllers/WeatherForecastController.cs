using Microsoft.AspNetCore.Mvc;
using HybridCacheExample.Services;
using HybridCacheExample.Models;

namespace HybridCacheExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IWeatherService weatherService,
        ILogger<WeatherForecastController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    [HttpGet("{city}")]
    public async Task<ActionResult<OpenWeatherResponse>> Get(string city)
    {
        try
        {
            var weather = await _weatherService.GetCurrentWeatherAsync(city);
            return Ok(weather);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting weather for city: {City}", city);
            return StatusCode(500, "Error fetching weather data");
        }
    }
}