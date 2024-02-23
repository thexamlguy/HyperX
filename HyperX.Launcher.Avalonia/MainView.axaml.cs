using Avalonia.Controls;
using HyperX.UI.Windows;

namespace HyperX.Launcher.Avalonia;

[NavigationTarget("Root")]
public partial class MainView : 
    UserControl
{
    public MainView() => 
        InitializeComponent();
}
