using PokeApiNet;

namespace WebAppRenderModes.Shared;

public sealed class GetPokemonByNameResponse : ResponseBase
{
    public Pokemon? Pokemon { get; private set; }
    
    public GetPokemonByNameResponse()
    {
    }
    
    public GetPokemonByNameResponse(Pokemon pokemon)
    {
        Pokemon = pokemon;
    }

    public GetPokemonByNameResponse(Exception ex) : base(ex)
    {
    }
}