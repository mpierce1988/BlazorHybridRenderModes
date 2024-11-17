namespace WebAppRenderModes.Shared.Models.Weather;

public class GetLocationsByNameResponse : ResponseBase
{
    public List<Location> Locations { get; set; } = new();
    
    public GetLocationsByNameResponse()
    {
    }
    
    public GetLocationsByNameResponse(List<Location> locations)
    {
        Locations = locations;
    }

    public GetLocationsByNameResponse(GeocodingApiResponse apiResponse)
    {
        Locations = apiResponse.results.Select(locationData => new Location(
            locationData.name,
            locationData.latitude,
            locationData.longitude,
            locationData.admin1,
            locationData.country_code
        )).ToList();
    }
    
    public GetLocationsByNameResponse(Exception exception) : base(exception)
    {
    }
}