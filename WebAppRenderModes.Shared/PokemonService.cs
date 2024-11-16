using System.Net;
using PokeApiNet;

namespace WebAppRenderModes.Shared;

public class PokemonService : IPokemonService
{
    private readonly PokeApiClient _pokeApiClient = new PokeApiClient();
    
    public async Task<GetPokemonByNameResponse> GetPokemonByNameAsync(string name)
    {
        try
        {
            Pokemon result = await _pokeApiClient.GetResourceAsync<Pokemon>(name);

            return new(result);
        }
        catch (HttpRequestException ex)
        {
            // Any status other than 404 is an unexpected error; throw to the next Exception handler
            if (ex.StatusCode != HttpStatusCode.NotFound) throw;
            
            // If the StatusCode is NotFound, then the Pokemon was not found (i.e. you searched for "Batman" - not a Pokemon!)
            return new GetPokemonByNameResponse();
        }
        catch (Exception ex)
        {
            return new(ex);

        }
    }
}