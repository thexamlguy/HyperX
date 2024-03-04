namespace HyperX.Widgets;

public record WidgetsConfiguration : 
    ComponentConfiguration
{
    public List<WidgetLayout> Layouts { get; set; } = [];
}
