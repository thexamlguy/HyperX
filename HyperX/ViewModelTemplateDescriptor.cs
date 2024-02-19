using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public class ViewModelTemplateDescriptor(IServiceProvider provider, 
    object key,
    Type viewModelType, 
    Type viewType) :
    IViewModelTemplateDescriptor
{
    private readonly IServiceProvider provider = provider;

    public object Key => key;

    public Type ViewModelType => viewModelType;

    public Type ViewType => viewType;

    public object? GetView()
    {
        if (provider.GetRequiredKeyedService(ViewType, key) is object view)
        {
            return view;
        }

        return default;
    }

    public object? GetViewModel()
    {
        if (provider.GetRequiredKeyedService(viewModelType, key) is object view)
        {
            return view;
        }

        return default;
    }
}