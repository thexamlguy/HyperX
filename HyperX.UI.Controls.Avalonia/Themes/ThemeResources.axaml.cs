using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace HyperX.UI.Controls.Avalonia;

public class ThemeResources :
    Styles
{
    public ThemeResources(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
