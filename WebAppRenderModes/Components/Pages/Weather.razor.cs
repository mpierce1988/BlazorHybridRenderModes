using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Client.Shared;
using WebAppRenderModes.Client.Shared.Weather;
using WebAppRenderModes.Shared.Models.Weather;
using WebAppRenderModes.Shared.Services;

namespace WebAppRenderModes.Components.Pages;

public partial class Weather
{
    [Inject] public required IWeatherService WeatherService { get; set; }
    private GetWeatherByLocationResponse? _response;

    private bool _isLoading = false;
    private string? _errorMessage;
    private GetWeatherByLocationRequest? _lastRequest;
    
    // Location Search
    private List<Location> _locations = new();
    
    // Weather Data for Chart
    private List<string>? _chartLabels;

    private List<WeatherChart.WeatherData>? _temperateData;
    private List<WeatherChart.WeatherData>? _windData;
    
    private async Task GetWeather(GetWeatherByLocationRequest request)
    {
        _lastRequest = request;
        _isLoading = true;
        
        try
        {
            Reset();

            GetWeatherByLocationResponse response = await WeatherService.GetWeatherByLocationAsync(request);

            if (!response.IsSuccess)
            {
                throw response.Exception ?? new Exception("Failed to get weather data");
            }

            PopulateWeatherData(response);
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

    private void PopulateWeatherData(GetWeatherByLocationResponse response)
    {
        _response = response;
        
        _chartLabels = response.DailyWeatherInfo.Select(x => x.Date.ToShortDateString()).ToList();
        
        // Create temperature data
        WeatherChart.WeatherData minTemps = new WeatherChart.WeatherData("Min Temp",
            _response.DailyWeatherInfo.Select(dw => dw.TemperatureTwoMeterMin).ToList());

        WeatherChart.WeatherData maxTemps = new WeatherChart.WeatherData("Max Temp",
            _response.DailyWeatherInfo.Select(dw => dw.TemperatureTwoMeterMax).ToList());
        
        WeatherChart.WeatherData avgTemps = new WeatherChart.WeatherData("Avg Temp",
            _response.DailyWeatherInfo.Select(dw => dw.TemperatureTwoMeterMin + (dw.TemperatureTwoMeterMax - dw.TemperatureTwoMeterMin) / 2).ToList());
        
        _temperateData = new List<WeatherChart.WeatherData> { minTemps, maxTemps, avgTemps };
        
        // Create wind data
        WeatherChart.WeatherData windSpeed = new WeatherChart.WeatherData("Average Wind Speed",
            _response.DailyWeatherInfo.Select(dw => dw.WindSpeedTenMeterMax).ToList());
        
        WeatherChart.WeatherData windGusts = new WeatherChart.WeatherData("Gusts",
            _response.DailyWeatherInfo.Select(dw => dw.WindGustsTenMeterMax).ToList());
        
        _windData = new List<WeatherChart.WeatherData> { windSpeed, windGusts };
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

    private void Reset()
    {
        _response = null;
        _chartLabels = null;
        _temperateData = null;
        _windData = null;
        _errorMessage = null;
    }
}