namespace HybridCacheExample.Models;

public class OpenWeatherResponse
{
    public MainData Main { get; set; } = null!;
    public string Name { get; set; } = null!;
    public WeatherData[] Weather { get; set; } = null!;
}

public class MainData
{
    public float Temp { get; set; }
    public float Feels_like { get; set; }
    public float Temp_min { get; set; }
    public float Temp_max { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}

public class WeatherData
{
    public string Main { get; set; } = null!;
    public string Description { get; set; } = null!;
} 