using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Shared.Models.Weather;

namespace WebAppRenderModes.Client.Shared;

public partial class SearchSelectLocationDialog : ComponentBase
{
    [Parameter] public EventCallback<string> OnSearchLocation { get; set; }
    [Parameter] public List<Location> Locations { get; set; } = new();
    [Parameter] public EventCallback<Location> OnLocationSelected { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }

    private class InputModel
    {
        public string SearchText { get; set; } = string.Empty;
    };

    private InputModel _inputModel = new();
    private Modal _modal;

    private string? _errorMessage;
    private bool _isLoading;

    private Grid<Location>? _grid;

    protected override async Task OnParametersSetAsync()
    {
        if(_grid is not null)
            await _grid.RefreshDataAsync();
        
        await base.OnParametersSetAsync();
    }

    private async Task SearchLocation()
    {
        if (string.IsNullOrEmpty(_inputModel.SearchText)) return;

        _isLoading = true;
        
        if (OnSearchLocation.HasDelegate)
            await OnSearchLocation.InvokeAsync(_inputModel.SearchText);
        
        _isLoading = false;
    }

    private async Task SelectLocation(Location location)
    {
        await _modal.HideAsync();
        
        if (OnLocationSelected.HasDelegate)
            await OnLocationSelected.InvokeAsync(location);
    }

    public async Task ShowDialog()
    {
        await _modal.ShowAsync();
    }

    private async Task<GridDataProviderResult<Location>> LocationsDataProvider(
        GridDataProviderRequest<Location> request)
    {
        return await Task.FromResult(request.ApplyTo(Locations));
    }
}