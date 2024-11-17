using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Client.Shared;
using WebAppRenderModes.Shared.Models.Weather;
using WebAppRenderModes.Shared.Services;

namespace WebAppRenderModes.Components.Pages;

public partial class Weather
{
    [Inject] public required IWeatherService WeatherService { get; set; }

    private GetWeatherByLocationRequest _request = new();

    private GetWeatherByLocationResponse? _response;

    private bool _isLoading = false;
    private string? _errorMessage;
    
    // Location Search
    private List<Location> _locations = new();

    private SearchSelectLocationDialog? _searchSelectLocationDialog;
    
    private async Task GetWeather()
    {
        _isLoading = true;
        
        try
        {
            _response = null;
            _errorMessage = null;

            GetWeatherByLocationResponse response = await WeatherService.GetWeatherByLocationAsync(_request);

            if (!response.IsSuccess)
            {
                throw response.Exception ?? new Exception("Failed to get weather data");
            }

            _response = response;

        }
        catch (Exception e)
        {
            _errorMessage = e.Message;
        }
        finally
        {
            _isLoading = false;
            await Task.Yield(); // Force a re-render
        }
    }

    private async Task ShowSearchLocationDialog()
    {
        if(_searchSelectLocationDialog is not null)
            await _searchSelectLocationDialog.ShowDialog();
    }
    
    private void CloseSearchLocationDialog()
    {
    }

    private async Task SearchLocations(string location)
    {
        try
        {
            GetLocationsByNameResponse response = await WeatherService.GetLocationsByNameAsync(new GetLocationsByNameRequest
            {
                Location = location
            });

            if (!response.IsSuccess)
            {
                throw response.Exception ?? new Exception("Failed to get locations");
            }

            _locations = response.Locations;
        }
        catch (Exception e)
        {
            _errorMessage = e.Message;
            _locations = new();
        }
    }
    
    private async Task SelectLocation(Location location)
    {
        _request.Latitude = location.Latitude;
        _request.Longitude = location.Longitude;
        await Task.Yield(); // Force a re-render
    }
}