using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public class ViewModelTemplateDescriptor(IServiceProvider provider,
    IServiceFactory serviceFactory,
    object key,
    Type viewModelType, 
    Type viewType) :
    IViewModelTemplateDescriptor
{
    private readonly IServiceProvider provider = provider;

    public object Key => key;

    public Type ViewModelType => viewModelType;

    public Type ViewType => viewType;

    public object? GetView() => 
        provider.GetRequiredKeyedService(ViewType, key) 
            is object view ? view : default;

    public object? GetViewModel(object?[]? parameters = null)
    {
        if (parameters is { Length: > 0 })
        {
            return serviceFactory.Create(viewModelType, parameters);
        }

        if (provider.GetRequiredKeyedService(viewModelType, key) is object viewModel)
        {
            return viewModel;
        }

        return default;
    }
}