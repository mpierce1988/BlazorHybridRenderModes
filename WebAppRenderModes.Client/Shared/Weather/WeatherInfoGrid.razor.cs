using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Shared.Models.Weather;

namespace WebAppRenderModes.Client.Shared.Weather;

public partial class WeatherInfoGrid : ComponentBase
{
    [Parameter] public List<DailyWeatherInfo> DailyWeatherInfo { get; set; } = new();
    
    private async Task<GridDataProviderResult<DailyWeatherInfo>> WeatherInfoDataProvider(GridDataProviderRequest<DailyWeatherInfo> request)
    {
        return await Task.FromResult(request.ApplyTo(DailyWeatherInfo));
    }
}