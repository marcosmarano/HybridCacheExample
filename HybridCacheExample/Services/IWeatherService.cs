using HybridCacheExample.Models;

namespace HybridCacheExample.Services;

public interface IWeatherService
{
    Task<OpenWeatherResponse?> GetCurrentWeatherAsync(string city);
} 