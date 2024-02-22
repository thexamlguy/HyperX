using Avalonia.Controls;

namespace HyperX.Keyboard.Avalonia;

public partial class LowerAlphabeticalLayoutNavigationView : 
    RadioButton
{
    public LowerAlphabeticalLayoutNavigationView() => 
        InitializeComponent();

    protected override Type StyleKeyOverride => 
        typeof(RadioButton);
}
