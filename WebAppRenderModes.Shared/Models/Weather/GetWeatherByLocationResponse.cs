namespace WebAppRenderModes.Shared.Models.Weather;

public class GetWeatherByLocationResponse : ResponseBase
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Elevation { get; set; }
    
    public List<DailyWeatherInfo> DailyWeatherInfo { get; set; } = new();

    public GetWeatherByLocationResponse()
    {
        
    }

    public GetWeatherByLocationResponse(WeatherApiResponse apiResponse)
    {
        Longitude = apiResponse.longitude;
        Latitude = apiResponse.latitude;
        Elevation = apiResponse.elevation;

        DailyWeatherInfo = new();

        int resultsCount = apiResponse.daily.weather_code.Length;

        for (int i = 0; i < resultsCount; i++)
        {
            DateTime? date = DateTime.TryParse(apiResponse.daily.time[i], out DateTime parsedDate) ? parsedDate : (DateTime?)null;
            int? weatherCode = apiResponse.daily.weather_code[i];
            double? temperatureTwoMeterMax = apiResponse.daily.temperature_2m_max[i];
            double? temperatureTwoMeterMin = apiResponse.daily.temperature_2m_min[i];
            DateTime? sunrise = DateTime.TryParse(apiResponse.daily.sunrise[i], out DateTime parsedSunrise) ? parsedSunrise : (DateTime?)null;
            DateTime? sunset = DateTime.TryParse(apiResponse.daily.sunset[i], out DateTime parsedSunset) ? parsedSunset : (DateTime?)null;
            double? precipitationSum = apiResponse.daily.precipitation_sum[i];
            double? rainSum = apiResponse.daily.rain_sum[i];
            double? showersSum = apiResponse.daily.showers_sum[i];
            double? snowfallSum = apiResponse.daily.snowfall_sum[i];
            double? precipitationHours = apiResponse.daily.precipitation_hours[i];
            double? precipitationProbabilityMax = apiResponse.daily.precipitation_probability_max[i];
            double? windSpeedTenMeterMax = apiResponse.daily.wind_speed_10m_max[i];
            double? windGustsTenMeterMax = apiResponse.daily.wind_gusts_10m_max[i];
            
            DailyWeatherInfo.Add(new DailyWeatherInfo
            {
                Date = date ?? DateTime.MinValue,
                WeatherCode = weatherCode,
                TemperatureTwoMeterMax = temperatureTwoMeterMax,
                TemperatureTwoMeterMin = temperatureTwoMeterMin,
                Sunrise = sunrise,
                Sunset = sunset,
                PrecipitationSum = precipitationSum,
                RainSum = rainSum,
                ShowersSum = showersSum,
                SnowfallSum = snowfallSum,
                PrecipitationHours = precipitationHours,
                PrecipitationProbabilityMax = precipitationProbabilityMax,
                WindSpeedTenMeterMax = windSpeedTenMeterMax,
                WindGustsTenMeterMax = windGustsTenMeterMax
            });
        }
    }
}