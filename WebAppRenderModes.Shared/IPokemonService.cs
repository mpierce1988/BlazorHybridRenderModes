using PokeApiNet;

namespace WebAppRenderModes.Shared;

public interface IPokemonService
{
    public Task<GetPokemonByNameResponse> GetPokemonByNameAsync(string name);
}