using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Shared.Models.Weather;

namespace WebAppRenderModes.Client.Shared;

public partial class SearchWeatherLatitudeLongitude : ComponentBase
{
    [EditorRequired]
    [Parameter] public List<Location> Locations { get; set; } = new();
    
    [EditorRequired]
    [Parameter] public EventCallback<GetWeatherByLocationRequest> OnSearchWeather { get; set; }
    
    [EditorRequired]
    [Parameter] public EventCallback<string> OnSearchLocation { get; set; }
    
    private GetWeatherByLocationRequest SearchRequest { get; set; } = new();

    private SearchSelectLocationDialog? _searchSelectLocationDialog;

    private async Task SearchWeather()
    {
        if (OnSearchWeather.HasDelegate)
            await OnSearchWeather.InvokeAsync(SearchRequest);
    }

    private async Task SearchLocation(string searchText)
    {
        if (OnSearchLocation.HasDelegate)
            await OnSearchLocation.InvokeAsync(searchText);
    }

    private async Task SetLocation(Location location)
    {
        SearchRequest.Latitude = location.Latitude;
        SearchRequest.Longitude = location.Longitude;
        await Task.Yield(); // Force a re-render
    }

    private async Task ShowSearchLocationDialog()
    {
        if (_searchSelectLocationDialog is not null)
            await _searchSelectLocationDialog.ShowDialog();
    }
}