using Avalonia.Controls;
using HyperX.UI.Windows;

namespace HyperX.Widgets.Avalonia;

[NavigationTarget("WidgetContainer")]
public partial class WidgetContainerView : 
    UserControl
{
    public WidgetContainerView()
    {
        InitializeComponent();

        foo.Click += Foo_Click;
    }

    private void Foo_Click(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        foo.Content = Guid.NewGuid();
    }
}
