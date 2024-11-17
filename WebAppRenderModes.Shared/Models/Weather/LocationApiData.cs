namespace WebAppRenderModes.Shared.Models.Weather;

public record LocationApiData(
    int id,
    string name,
    double latitude,
    double longitude,
    double elevation,
    string feature_code,
    string country_code,
    int admin1_id,
    int admin2_id,
    string timezone,
    int population,
    int country_id,
    string country,
    string admin1,
    string admin2
);