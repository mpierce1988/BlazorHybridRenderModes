using Microsoft.AspNetCore.Components;

namespace WebAppRenderModes.Client.Shared;

public partial class SearchTextBox : ComponentBase
{
    [Parameter] public bool ResultFound { get; set; }
    
    [Parameter] public EventCallback<string> OnSearch { get; set; }
    [Parameter] public EventCallback OnReset { get; set; }
    
    private string _inputString = string.Empty;

    public async Task Search()
    {
        if (string.IsNullOrEmpty(_inputString)) return;

        await OnSearch.InvokeAsync(_inputString);
    }

    public async Task Clear()
    {
        _inputString = string.Empty;

        await OnReset.InvokeAsync();
    }
}