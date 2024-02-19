using Avalonia.Controls;
using System;

namespace HyperX.Spotify.Avalonia;

public partial class UpperAlphabeticalKeyboardLayoutNavigationView : 
    RadioButton
{
    public UpperAlphabeticalKeyboardLayoutNavigationView() => 
        InitializeComponent();

    protected override Type StyleKeyOverride => typeof(RadioButton);
}
