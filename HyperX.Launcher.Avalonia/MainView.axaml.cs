using Avalonia.Controls;
using Avalonia.Media;
using HyperX.UI.Controls.Avalonia;
using HyperX.UI.Windows;

namespace HyperX.Launcher.Avalonia;

[NavigationTarget("Root")]
[NavigationTarget("Header")]
public partial class MainView : 
    UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
}
