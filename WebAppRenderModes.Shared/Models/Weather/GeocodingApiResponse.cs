namespace WebAppRenderModes.Shared.Models.Weather;

public record GeocodingApiResponse(
    LocationApiData[] results,
    double generationtime_ms
);