using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using Microsoft.Extensions.DependencyInjection;

namespace HyperX.Avalonia;

public class ContentTemplate :
    IContentTemplate,
    IDataTemplate
{
    public Control? Build(object? item)
    {
        if (item is IObservableViewModel observableViewModel)
        {
            if (observableViewModel.ServiceProvider is IServiceProvider provider)
            {
                IContentTemplateDescriptorProvider? contentTemplateProvider = provider.GetService<IContentTemplateDescriptorProvider>();
                INavigationContext? viewModelContentBinder = provider.GetService<INavigationContext>();

                if (contentTemplateProvider?.Get(item.GetType().Name) is IContentTemplateDescriptor descriptor)
                {
                    if (provider.GetRequiredKeyedService(descriptor.TemplateType, descriptor.Key) is Control control)
                    {
                        async void HandleLoaded(object? sender, RoutedEventArgs args)
                        {
                            control.Loaded -= HandleLoaded;
                            if (control.DataContext is object content)
                            {
                                if (content is IInitializer initializer)
                                {
                                    await initializer.Initialize();
                                }

                                if (content is IActivated activated)
                                {
                                    await activated.Activated();
                                }
                            }
                        }

                        control.Loaded += HandleLoaded;
                        viewModelContentBinder?.Set(control);

                        return control;
                    }
                }
            }
        }

        return default;
    }

    public bool Match(object? data) => true;
}
