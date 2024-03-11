﻿using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public class NavigationScope(IPublisher publisher,
    IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    INavigationProvider navigationProvider,
    INavigationContextProvider navigationContextProvider,
    IContentTemplateDescriptorProvider contentTemplateDescriptorProvider) : 
    INavigationScope
{
    public async Task NavigateAsync(object key, object? sender, 
        object? context, object[]? parameters = null, 
        CancellationToken cancellationToken = default)
    {
        if (contentTemplateDescriptorProvider.Get(key)
            is IContentTemplateDescriptor descriptor)
        {
            Dictionary<string, object>? arguments = parameters?.OfType<KeyValuePair<string, object>>()
                .ToDictionary(x => x.Key, x => x.Value, StringComparer.InvariantCultureIgnoreCase) ?? [];

            IEnumerable<object?>? mappedParameters = descriptor.ContentType
                 .GetConstructors()
                 .FirstOrDefault()?
                 .GetParameters()
                 .Select(parameter => parameter?.Name is not null && arguments
                     .TryGetValue(parameter.Name, out object? argument) ? argument : default)
                 .Where(argument => argument is not null);

            parameters = [.. parameters?.Where(x => x.GetType() != typeof(KeyValuePair<string, object>)) ?? Enumerable.Empty<object?>(), .. mappedParameters ?? Enumerable.Empty<object?>()];

            if (serviceProvider.GetRequiredKeyedService(descriptor.TemplateType, key) is object view)
            {
                if ((parameters is { Length: > 0 }
                    ? serviceFactory.Create(descriptor.ContentType, parameters)
                    : serviceProvider.GetRequiredKeyedService(descriptor.ContentType, key)) is object viewModel)
                {
                    if (context is not null)
                    {
                        if (navigationContextProvider.TryGet(context, out object? scopedContext))
                        {
                            context = scopedContext;
                        }
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
                            if (Activator.CreateInstance(navigateType, [context, view, viewModel, sender, parameters]) is object navigate)
                            {
                                await publisher.Publish(navigate, cancellationToken);
                            }
                        }
                    }
                }
            }
        }
    }

    public async Task NavigateBackAsync(object? context, 
        CancellationToken cancellationToken = default)
    {
        if (context is not null)
        {
            navigationContextProvider.TryGet(context, out context);
        }

        if (context is not null)
        {
            if (navigationProvider.Get(context is Type type ? type : context.GetType())
                is INavigation navigation)
            {
                Type navigateType = typeof(NavigateBack<>).MakeGenericType(navigation.Type);
                if (Activator.CreateInstance(navigateType, [context]) is object navigate)
                {
                    await publisher.Publish(navigate, cancellationToken);
                }
            }
        }
    }
}

