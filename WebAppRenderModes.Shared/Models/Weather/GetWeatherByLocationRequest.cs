using System.ComponentModel.DataAnnotations;

namespace WebAppRenderModes.Shared.Models.Weather;

public class GetWeatherByLocationRequest
{
    [Required(ErrorMessage = "Longitude is required")]
    public double? Longitude { get; set; }
    
    [Required(ErrorMessage = "Latitude is required")]
    public double? Latitude { get; set; }

    [Range(0, 16, ErrorMessage = "Forecast days must be between 0 and 16")]
    public int ForecastDays { get; set; } = 7;
}