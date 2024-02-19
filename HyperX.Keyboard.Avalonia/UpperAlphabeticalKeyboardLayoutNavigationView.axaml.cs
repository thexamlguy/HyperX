using Avalonia.Controls;

namespace HyperX.Keyboard.Avalonia;

public partial class UpperAlphabeticalKeyboardLayoutNavigationView : 
    RadioButton
{
    public UpperAlphabeticalKeyboardLayoutNavigationView() => 
        InitializeComponent();

    protected override Type StyleKeyOverride => typeof(RadioButton);
}
