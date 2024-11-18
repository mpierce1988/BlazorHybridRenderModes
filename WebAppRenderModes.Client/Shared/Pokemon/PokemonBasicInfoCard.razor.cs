using Microsoft.AspNetCore.Components;

namespace WebAppRenderModes.Client.Shared.Pokemon;

public partial class PokemonBasicInfoCard : ComponentBase
{
    [EditorRequired]
    [Parameter] 
    public required PokeApiNet.Pokemon Pokemon { get; set; }
}