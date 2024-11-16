using Microsoft.Extensions.DependencyInjection;

namespace WebAppRenderModes.Shared;

public static class Configuration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();
        services.AddScoped<TestService>();
    }
}