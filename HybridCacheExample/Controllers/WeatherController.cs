using HybridCacheExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace HybridCacheExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController(
    IWeatherService weatherService,
    ILogger<WeatherController> logger)
    : ControllerBase
{
    [HttpGet("{city}")]
    public async Task<IResult> Get(string city)
    {
        try
        {
            var weather = await weatherService.GetCurrentWeatherAsync(city);
            return weather is null ? Results.NotFound() : Results.Ok(weather);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting weather for city: {City}", city);
            return Results.InternalServerError("Error fetching weather data");
        }
    }
}