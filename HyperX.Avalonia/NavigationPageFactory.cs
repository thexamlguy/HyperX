using Avalonia.Controls;
using FluentAvalonia.UI.Controls;

namespace HyperX.Avalonia;

public class NavigationPageFactory : 
    INavigationPageFactory
{
    public Control? GetPage(Type srcType)
    {
        return default;
    }

    public Control GetPageFromObject(object target)
    {
        return (Control)target;
    }
}
