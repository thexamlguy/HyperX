using Avalonia.Controls;

namespace HyperX.Keyboard.Avalonia;

public partial class UpperAlphabeticalLayoutNavigationView : 
    RadioButton
{
    public UpperAlphabeticalLayoutNavigationView() => 
        InitializeComponent();

    protected override Type StyleKeyOverride => 
        typeof(RadioButton);
}
