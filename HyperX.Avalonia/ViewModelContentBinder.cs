using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using HyperX.UI.Windows;
using System.Reflection;

namespace HyperX.Avalonia;

public class ViewModelContentBinder(INavigationContextCollection contexts) :
    IViewModelContentBinder
{
    public void Bind(TemplatedControl view,
        object context)
    {
        if (context.GetType().GetCustomAttributes<NavigationTargetAttribute>()
            is IEnumerable<NavigationTargetAttribute> attributes)
        {
            foreach (NavigationTargetAttribute attribute in attributes)
            {
                if (!contexts.ContainsKey(attribute.Name))
                {
                    if (view.Find<TemplatedControl>(attribute.Name) is TemplatedControl content)
                    {
                        contexts.Add(attribute.Name, content);
                        void HandleUnloaded(object? sender, RoutedEventArgs args)
                        {
                            view.Unloaded -= HandleUnloaded;
                            contexts.Remove(attribute.Name);
                        }

                        view.Unloaded += HandleUnloaded;
                    }
                }
            }
        }
    }
}

