using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Shared.Models.Weather;

namespace WebAppRenderModes.Client.Shared.Weather;

public partial class SearchWeatherLatitudeLongitude : ComponentBase
{
    [EditorRequired]
    [Parameter] public List<Location> Locations { get; set; } = new();
    
    [EditorRequired]
    [Parameter] public EventCallback<GetWeatherByLocationRequest> OnSearchWeather { get; set; }
    
    [EditorRequired]
    [Parameter] public EventCallback<string> OnSearchLocation { get; set; }
    
    [Parameter] public EventCallback OnReset { get; set; }
    
    private GetWeatherByLocationRequest _searchRequest = new();

    private SearchSelectLocationDialog? _searchSelectLocationDialog;

    private bool _isLoadingWeather = false;

    private async Task SearchWeather()
    {
        if (OnSearchWeather.HasDelegate)
        {
            _isLoadingWeather = true;
            await OnSearchWeather.InvokeAsync(_searchRequest);
            _isLoadingWeather = false;
        }
            
    }

    private async Task SearchLocation(string searchText)
    {
        if (OnSearchLocation.HasDelegate)
            await OnSearchLocation.InvokeAsync(searchText);
    }

    private async Task SetLocation(Location location)
    {
        _searchRequest.Latitude = location.Latitude;
        _searchRequest.Longitude = location.Longitude;
        await Task.Yield(); // Force a re-render
    }

    private async Task ShowSearchLocationDialog()
    {
        if (_searchSelectLocationDialog is not null)
            await _searchSelectLocationDialog.ShowDialog();
    }

    private async Task Reset()
    {
        _searchRequest = new();

        if (OnReset.HasDelegate)
        {
            await OnReset.InvokeAsync();
        }
    }
}