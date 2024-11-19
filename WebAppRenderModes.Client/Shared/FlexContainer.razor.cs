using Microsoft.AspNetCore.Components;

namespace WebAppRenderModes.Client.Shared;

public partial class FlexContainer : ComponentBase
{
    /// <summary>
    /// The alignment of items along the cross axis (default: center).
    /// </summary>
    [Parameter]
    public string AlignItems { get; set; } = "center";

    /// <summary>
    /// The alignment of items along the main axis (default: center).
    /// </summary>
    [Parameter]
    public string JustifyContent { get; set; } = "center";

    /// <summary>
    /// The direction of the flex container (default: column).
    /// </summary>
    [Parameter]
    public string FlexDirection { get; set; } = "column";

    /// <summary>
    /// The width of the container (optional).
    /// </summary>
    [Parameter]
    public string? Width { get; set; }

    /// <summary>
    /// The height of the container (default: 6rem).
    /// </summary>
    [Parameter]
    public string? Height { get; set; } = "6rem";

    /// <summary>
    /// The content to be rendered inside the flex container.
    /// </summary>
    [Parameter]
    public required RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Builds the inline style string based on provided parameters.
    /// </summary>
    private string Style =>
        $"display: flex; " +
        $"flex-direction: {FlexDirection}; " +
        $"align-items: {AlignItems}; " +
        $"justify-content: {JustifyContent}; " +
        $"{(Width != null ? $"width: {Width}; " : "")}" +
        $"{(Height != null ? $"height: {Height}; " : "")}";
}