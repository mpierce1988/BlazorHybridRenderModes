using Microsoft.AspNetCore.Components;
using PokeApiNet;

namespace WebAppRenderModes.Client.Shared;

public partial class PokemonBasicInfoCard : ComponentBase
{
    [EditorRequired]
    [Parameter] 
    public required Pokemon Pokemon { get; set; }
}