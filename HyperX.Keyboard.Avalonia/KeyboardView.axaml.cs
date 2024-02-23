using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace HyperX.Keyboard.Avalonia;

public partial class KeyboardView : 
    UserControl
{
    public KeyboardView() => 
        InitializeComponent();

    protected override void OnLoaded(RoutedEventArgs args)
    {
        Input.Focus();
        base.OnLoaded(args);
    }
}
