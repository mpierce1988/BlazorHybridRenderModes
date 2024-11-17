using System.Text.Json;
using WebAppRenderModes.Shared.Models.Weather;

namespace WebAppRenderModes.Shared.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    
    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<GetWeatherByLocationResponse> GetWeatherByLocationAsync(GetWeatherByLocationRequest request)
    {
        GetWeatherByLocationResponse response = new();
        
        try
        {
            if (request.Latitude == null || request.Longitude == null)
            {
                throw new Exception("Latitude and Longitude are required");
            }

            string url = GetWeatherApiUrl(request.Latitude.Value, request.Longitude.Value, request.ForecastDays);
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);

            httpResponse.EnsureSuccessStatusCode();

            string json = await httpResponse.Content.ReadAsStringAsync();
            WeatherApiResponse? weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(json);

            if (weatherData is null)
            {
                throw new Exception("Failed to parse response from API into WeatherApiResponse class");
            }
            
            response = new GetWeatherByLocationResponse(weatherData);
        }
        catch (Exception e)
        {
            response.Exception = e;
        }

        return response;
    }

    public async Task<GetLocationsByNameResponse> GetLocationsByNameAsync(GetLocationsByNameRequest request)
    {
        GetLocationsByNameResponse response;

        try
        {
            if (string.IsNullOrEmpty(request.Location))
            {
                throw new ArgumentNullException(nameof(request.Location), "Location is required");
            }
            
            string url = GetLocationApiUrl(request.Location);
            
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            
            httpResponse.EnsureSuccessStatusCode();
            
            string json = await httpResponse.Content.ReadAsStringAsync();
            
            GeocodingApiResponse? geocodingData = JsonSerializer.Deserialize<GeocodingApiResponse>(json);
            
            if (geocodingData is null)
            {
                throw new Exception("Failed to parse response from API into GeocodingApiResponse class");
            }

            response = new GetLocationsByNameResponse(geocodingData);
        }
        catch (Exception e)
        {
            response = new GetLocationsByNameResponse(e);
        }
        
        return response;
    }

    private string GetLocationApiUrl(string locationName)
    {
        return $"https://geocoding-api.open-meteo.com/v1/search?name={locationName}&count=100&language=en&format=json";
    }

    private string GetWeatherApiUrl(double latitude, double longitude, int forecastDays)
    {
        return
            $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&forecast_days={forecastDays}&daily=weather_code,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_sum,rain_sum,showers_sum,snowfall_sum,precipitation_hours,precipitation_probability_max,wind_speed_10m_max,wind_gusts_10m_max&timezone=GMT";
    }
}