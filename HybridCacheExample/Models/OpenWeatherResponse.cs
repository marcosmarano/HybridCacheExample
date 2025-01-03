using System.Text.Json.Serialization;

namespace HybridCacheExample.Models;

public class OpenWeatherResponse
{
    public Coord Coord { get; set; } = null!;
    public WeatherData[] Weather { get; set; } = null!;
    public string Base { get; set; } = null!;
    public MainData Main { get; set; } = null!;
    public int Visibility { get; set; }
    public Wind Wind { get; set; } = null!;
    public Clouds Clouds { get; set; } = null!;
    public long Dt { get; set; }
    public Sys Sys { get; set; } = null!;
    public int Timezone { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Cod { get; set; }
}

public class Coord
{
    public float Lon { get; set; }
    public float Lat { get; set; }
}

public class MainData
{
    public float Temp { get; set; }
    public float FeelsLike { get; set; }
    public float TempMin { get; set; }
    public float TempMax { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public int SeaLevel { get; set; }
    public int GrndLevel { get; set; }
}

public class WeatherData
{
    public int Id { get; set; }
    public string Main { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Icon { get; set; } = null!;
}

public class Wind
{
    public float Speed { get; set; }
    public int Deg { get; set; }
}

public class Clouds
{
    public int All { get; set; }
}

public class Sys
{
    public int Type { get; set; }
    public int Id { get; set; }
    public string Country { get; set; } = null!;
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
}