using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Shared.Models.Weather;

namespace WebAppRenderModes.Client.Shared.Weather;

public partial class WeatherInfoGrid : ComponentBase
{
    [Parameter] public List<DailyWeatherInfo> DailyWeatherInfo { get; set; } = new();
}