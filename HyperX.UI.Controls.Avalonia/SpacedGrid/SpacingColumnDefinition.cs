using Avalonia.Controls;

namespace HyperX.UI.Controls.Avalonia;

public class SpacingColumnDefinition(double width) :
    ColumnDefinition(width, GridUnitType.Pixel),
    ISpacingDefinition
{
    public double Spacing
    {
        get => Width.Value;
        set => Width = new GridLength(value, GridUnitType.Pixel);
    }
}
