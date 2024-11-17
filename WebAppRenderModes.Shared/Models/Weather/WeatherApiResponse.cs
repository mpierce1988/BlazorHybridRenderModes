namespace WebAppRenderModes.Shared.Models.Weather;

public record WeatherApiResponse(
    double latitude,
    double longitude,
    double generationtime_ms,
    int utc_offset_seconds,
    string timezone,
    string timezone_abbreviation,
    double elevation,
    Daily_units daily_units,
    Daily daily
);

public record Daily_units(
    string time,
    string weather_code,
    string temperature_2m_max,
    string temperature_2m_min,
    string sunrise,
    string sunset,
    string precipitation_sum,
    string rain_sum,
    string showers_sum,
    string snowfall_sum,
    string precipitation_hours,
    string precipitation_probability_max,
    string wind_speed_10m_max,
    string wind_gusts_10m_max
);

public record Daily(
    string[] time,
    int[] weather_code,
    double[] temperature_2m_max,
    double[] temperature_2m_min,
    string[] sunrise,
    string[] sunset,
    double[] precipitation_sum,
    double[] rain_sum,
    double[] showers_sum,
    double[] snowfall_sum,
    double[] precipitation_hours,
    int[] precipitation_probability_max,
    double[] wind_speed_10m_max,
    double[] wind_gusts_10m_max
);