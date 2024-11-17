using WebAppRenderModes.Shared.Models;

namespace WebAppRenderModes.Shared.Services;

public interface IPokemonService
{
    public Task<GetPokemonByNameResponse> GetPokemonByNameAsync(string name);
}