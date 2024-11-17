using Microsoft.Extensions.DependencyInjection;
using WebAppRenderModes.Shared.Services;

namespace WebAppRenderModes.Shared;

public static class Configuration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();
        services.AddScoped<IWeatherService, WeatherService>();
        services.AddScoped<TestService>();
    }
}