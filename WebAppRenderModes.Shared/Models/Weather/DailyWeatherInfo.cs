namespace WebAppRenderModes.Shared.Models.Weather;

public record DailyWeatherInfo
{
    public DateTime Date { get; set; }
    public int? WeatherCode { get; set; }
    public double? TemperatureTwoMeterMax { get; set; }
    public double? TemperatureTwoMeterMin { get; set; }
    public DateTime? Sunrise { get; set; }
    public DateTime? Sunset { get; set; }
    public double? PrecipitationSum { get; set; }
    public double? RainSum { get; set; }
    public double? ShowersSum { get; set; }
    public double? SnowfallSum { get; set; }
    public double? PrecipitationHours { get; set; }
    public double? PrecipitationProbabilityMax { get; set; }
    public double? WindSpeedTenMeterMax { get; set; }
    public double? WindGustsTenMeterMax { get; set; }
}