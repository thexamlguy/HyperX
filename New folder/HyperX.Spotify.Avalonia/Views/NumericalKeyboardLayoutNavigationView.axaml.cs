using Avalonia.Controls;
using System;

namespace HyperX.Spotify.Avalonia;

public partial class NumericalKeyboardLayoutNavigationView : RadioButton
{
    public NumericalKeyboardLayoutNavigationView() =>
        InitializeComponent();

    protected override Type StyleKeyOverride => typeof(RadioButton);
}

