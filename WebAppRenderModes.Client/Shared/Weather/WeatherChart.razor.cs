using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace WebAppRenderModes.Client.Shared.Weather;

public partial class WeatherChart : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public List<string> Labels { get; set; } = new List<string>();
    
    [Parameter]
    [EditorRequired]
    public List<WeatherData> Data { get; set; } = new();
    
    [Parameter]
    [EditorRequired]
    public required string Title { get; set; }
    
    [Parameter]
    [EditorRequired]
    public required string XAxisLabel { get; set; }
    
    [Parameter]
    [EditorRequired]
    public required string YAxisLabel { get; set; }
    
    [Parameter]
    public int? Height { get; set; }
    
    [Parameter]
    public Unit HeightUnit { get; set; } = Unit.Px;
    
    [Parameter]
    public int? Width { get; set; }
    
    [Parameter]
    public Unit WidthUnit { get; set; } = Unit.Px;
    
    private LineChart? _lineChart;
    private LineChartOptions? _lineChartOptions;
    private ChartData? _chartData;

    public record WeatherData(string Label, List<double?>? Data);
    
    protected override void OnInitialized()
    {
        // Set up chart options
        string[] colors = ColorUtility.CategoricalTwelveColors;

        List<IChartDataset> datasets = GetDatasets(colors);

        _chartData = new ChartData()
        {
            Labels = Labels,
            Datasets = datasets
        };

        _lineChartOptions = GetLineChartOptions();
        
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if(_lineChart != null && _chartData != null && _lineChartOptions != null)
                await _lineChart.InitializeAsync(_chartData, _lineChartOptions);
        }
        
        await base.OnAfterRenderAsync(firstRender);
    }

    private LineChartOptions GetLineChartOptions()
    {
        LineChartOptions options = new();

        options.Responsive = true;
        options.Interaction = new Interaction { Mode = InteractionMode.Index };

        if (options.Scales.X?.Title is not null && !string.IsNullOrEmpty(XAxisLabel))
        {
            options.Scales.X.Title.Text = XAxisLabel;
            options.Scales.X.Title.Display = true;
        }

        if (options.Scales.Y?.Title is not null && !string.IsNullOrEmpty(YAxisLabel))
        {
            options.Scales.Y.Title.Text = YAxisLabel;
            options.Scales.Y.Title.Display = true;
        }

        if (options.Plugins.Title is not null && !string.IsNullOrEmpty(Title))
        {
            options.Plugins.Title.Text = Title;
            options.Plugins.Title.Display = true;
        }

        return options;
    }

    private List<IChartDataset> GetDatasets(string[] colors)
    {
        List<IChartDataset> datasets = new();
        
        for (int i = 0; i < Data.Count; i++)
        {
            var data = Data[i];
            var color = colors[i % colors.Length];
            
            datasets.Add(new LineChartDataset
            {
                Label = data.Label,
                Data = data.Data,
                BackgroundColor = color,
                BorderColor = color,
                BorderWidth = 2,
                HoverBorderWidth = 2,
                PointBackgroundColor = new List<string> { color },
                Fill = false
            });
        }

        return datasets;
    }
}