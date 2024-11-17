using System.ComponentModel.DataAnnotations;

namespace WebAppRenderModes.Shared.Models.Weather;

public class GetLocationsByNameRequest
{
    [Required] public string Location { get; set; } = string.Empty;
}