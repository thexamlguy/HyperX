﻿using Avalonia.Controls;

namespace HyperX.UI.Controls.Avalonia;

public class SpacingRowDefinition(double height) :
    RowDefinition(height, GridUnitType.Pixel),
    ISpacingDefinition
{
    public double Spacing
    {
        get => Height.Value;
        set => Height = new GridLength(value, GridUnitType.Pixel);
    }
}
