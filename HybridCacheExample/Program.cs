using HybridCacheExample.Services;
#pragma warning disable EXTEXP0018

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, OpenWeatherService>();

// To use the in-memory cache, uncomment the following line
// builder.Services.AddMemoryCache();

// To use the distributed cache, uncomment the following line
// builder.Services.AddStackExchangeRedisCache(options =>
// {
//     options.Configuration = "localhost:XXXX";
//     options.InstanceName = "HybridCacheExample";
// });

builder.Services.AddHybridCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();