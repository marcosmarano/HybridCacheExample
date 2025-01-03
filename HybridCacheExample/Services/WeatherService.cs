using System.Net.Http.Json;
using HybridCacheExample.Models;
using Microsoft.Extensions.Configuration;

namespace HybridCacheExample.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<WeatherService> logger)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OpenWeatherMap:ApiKey"] ?? 
            throw new ArgumentNullException("OpenWeatherMap:ApiKey configuration is missing");
        _logger = logger;
        
        _httpClient.BaseAddress = new Uri(
            configuration["OpenWeatherMap:BaseUrl"] ?? 
            "https://api.openweathermap.org/data/2.5");
    }

    public async Task<OpenWeatherResponse> GetCurrentWeatherAsync(string city)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<OpenWeatherResponse>(
                $"/weather?q={city}&appid={_apiKey}&units=metric");

            if (response == null)
            {
                throw new Exception("Failed to get weather data");
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching weather data for city: {City}", city);
            throw;
        }
    }
} 