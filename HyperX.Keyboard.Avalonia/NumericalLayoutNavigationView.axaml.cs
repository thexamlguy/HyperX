using Avalonia.Controls;

namespace HyperX.Keyboard.Avalonia;

public partial class NumericalLayoutNavigationView : 
    RadioButton
{
    public NumericalLayoutNavigationView() =>
        InitializeComponent();

    protected override Type StyleKeyOverride =>
        typeof(RadioButton);
}

