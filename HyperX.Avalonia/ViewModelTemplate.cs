using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace HyperX.Avalonia;

public class ViewModelTemplate :
    IViewModelTemplate,
    IDataTemplate
{
    public Control? Build(object? item)
    {
        if (item is IObservableViewModel observableViewModel)
        {
            if (observableViewModel.ServiceProvider is IServiceProvider provider)
            {
                if (provider.GetService<IViewModelTemplateDescriptorProvider>()
                    is IViewModelTemplateDescriptorProvider viewModelTemplateProvider)
                {
                    if (viewModelTemplateProvider.Get(item.GetType().Name.Replace("ViewModel", "")) 
                        is IViewModelTemplateDescriptor descriptor)
                    {
                        if (provider.GetService<IViewModelContentBinder>()
                            is IViewModelContentBinder viewModelContentBinder)
                        {
                            if (provider.GetRequiredKeyedService(descriptor.ViewType, descriptor.Key) is TemplatedControl view)
                            {
                                viewModelContentBinder.Bind(view);
                                return view;
                            }
                        }
                    }
                }
            }
        }

        return default;
    }

    public bool Match(object? data) => true;
}
