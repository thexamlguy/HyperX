using Avalonia.Controls;
using System;

namespace HyperX.Spotify.Avalonia;

public partial class LowerAlphabeticalKeyboardLayoutNavigationView : 
    RadioButton
{
    public LowerAlphabeticalKeyboardLayoutNavigationView() => 
        InitializeComponent();

    protected override Type StyleKeyOverride => typeof(RadioButton);
}
