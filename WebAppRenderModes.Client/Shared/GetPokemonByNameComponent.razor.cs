using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Shared;
using WebAppRenderModes.Shared.Services;

namespace WebAppRenderModes.Client.Shared;

public partial class GetPokemonByNameComponent : ComponentBase
{
    [Inject] private IPokemonService? PokemonService { get; set; }

    private bool _isLoading = false;
    private string _errorMessage = string.Empty;

    private PokeApiNet.Pokemon? _pokemon;

    async Task Search(string searchText)
    {
        try
        {
            _isLoading = true;
            
            if (string.IsNullOrEmpty(searchText)) return;

            if (PokemonService is null)
            {
                _errorMessage = "Pokemon Service is not available.";
                _pokemon = null;
                return;
            }
            
            var result = await PokemonService.GetPokemonByNameAsync(searchText);

            _pokemon = null;
            _errorMessage = string.Empty;

            if (!result.IsSuccess)
            {
                _pokemon = null;
                _errorMessage = result.Exception!.Message;
                return;
            }

            if (result.Pokemon is null)
            {
                // No Pokémon was found
                _errorMessage = $"Pokemon with the name '{searchText}' not found";
                _pokemon = null;
                return;
            }

            _pokemon = result.Pokemon;
        }
        catch (Exception e)
        {
            _errorMessage = e.Message;
        }
        finally
        {
            _isLoading = false;
            StateHasChanged();
        }

    }

    void Reset()
    {
        _errorMessage = string.Empty;
        _pokemon = null;
    }
}