using WebAppRenderModes.Shared.Models;
using WebAppRenderModes.Shared.Models.Weather;

namespace WebAppRenderModes.Shared.Services;

public interface IWeatherService
{
    public Task<GetWeatherByLocationResponse> GetWeatherByLocationAsync(GetWeatherByLocationRequest request);
    public Task<GetLocationsByNameResponse> GetLocationsByNameAsync(GetLocationsByNameRequest request);
}



