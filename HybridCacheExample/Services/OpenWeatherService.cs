using System.Net;
using HybridCacheExample.Models;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCacheExample.Services;

public class OpenWeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;
    private readonly string _baseUrl;
    private readonly HybridCache _cache;

    public OpenWeatherService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        HybridCache cache)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = configuration["OpenWeatherMap:ApiKey"]!;
        _baseUrl = configuration["OpenWeatherMap:BaseUrl"]!;
        _cache = cache;
    }

    public async Task<OpenWeatherResponse?> GetCurrentWeatherAsync(string city) =>
        await _cache.GetOrCreateAsync<OpenWeatherResponse?>(
            $"weather:{city}",
            async _ => await GetWeatherAsync(city),
            options: new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromMinutes(15)
            },
            tags: [ "weather" ]);

    private async Task<OpenWeatherResponse?> GetWeatherAsync(string city)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(_baseUrl);

        var response = await httpClient.GetAsync($"weather?q={city}&appid={_apiKey}");
        
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<OpenWeatherResponse>();
    }
}