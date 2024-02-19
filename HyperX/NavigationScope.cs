namespace HyperX;

public class NavigationScope(IPublisher publisher,
    INavigationProvider navigationProvider,
    INavigationContextProvider navigationContextProvider,
    IViewModelTemplateProvider viewModelTemplateProvider) : 
    INavigationScope
{
    public async Task NavigateAsync(object key, object? context, 
        CancellationToken cancellationToken = default)
    {
        if (viewModelTemplateProvider.Get(key)
            is IViewModelTemplateDescriptor descriptor)
        {
            if (descriptor.GetView() is object view && 
                descriptor.GetViewModel() is object viewModel)
            {
                if (context is not null)
                {
                    navigationContextProvider.TryGet(context, out context);
                }
                else
                {
                    context = view;
                }

                if (context is not null)
                {
                    if (navigationProvider.Get(context is Type type ? type : context.GetType())
                        is INavigation navigation)
                    {
                        Type navigateType = typeof(Navigate<>).MakeGenericType(navigation.Type);
                        if (Activator.CreateInstance(navigateType, [context, view, viewModel]) is object navigate)
                        {
                            await publisher.PublishAsync(navigate, cancellationToken);
                        }
                    }
                }
            }
        }
    }
}

