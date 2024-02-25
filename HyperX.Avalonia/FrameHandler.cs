using Avalonia.Controls.Primitives;
using FluentAvalonia.UI.Navigation;
using HyperX.UI.Controls.Avalonia;
using System.Reflection;

namespace HyperX.Avalonia;

public class FrameHandler(IViewModelContentBinder binder,
    IProxyService<IPublisher> publisher) : 
    INavigateHandler<Frame>,
    INavigateBackHandler<Frame>
{
    public Task Handle(Navigate<Frame> args,
        CancellationToken cancellationToken)
    {
        if (args.Context is Frame frame)
        {
            frame.NavigationPageFactory ??= new NavigationPageFactory();
            if (args.View is TemplatedControl template)
            {
                void NavigatingFrom(object? sender, 
                    TemplatedControl template)
                {
                    async void HandleNavigatingFrom(object? _, 
                        NavigatingCancelEventArgs args)
                    {
                        Dictionary<string,object> results = [];

                        template.RemoveHandler(Frame.NavigatingFromEvent, HandleNavigatingFrom);
                        NavigatedFrom(sender, template, () => results);

                        if (template.DataContext is object content)
                        {
                            if (content is IConfirmNavigation confirmNavigation &&
                                !await confirmNavigation.ConfirmNavigationAsync())
                            {
                                args.Cancel = true;
                            }

                            if (!args.Cancel)
                            {
                                if (content is INavigatingFrom navigatingFrom)
                                {
                                    await navigatingFrom.NavigatingFromAsync();
                                }

                                Type contentType = content.GetType();
                                if (contentType.GetInterfaces() is Type[] contracts)
                                {
                                    foreach (Type contract in contracts)
                                    {
                                        if (contract.Name == typeof(INavigatingFrom<>).Name &&
                                            contract.GetGenericArguments() is { Length: 1 } arguments)
                                        {
                                            if (contentType.GetMethods().FirstOrDefault(x =>
                                                x.Name == "NavigatingFromAsync" && x.ReturnType == typeof(Task<>)
                                                    .MakeGenericType(arguments[0]))
                                                        is MethodInfo methodInfo)
                                            {
                                                if (methodInfo.GetCustomAttribute<NavigationParameterAttribute>()
                                                    is NavigationParameterAttribute attribute)
                                                {
                                                    if (await methodInfo.InvokeAsync<object?>(content) is object result)
                                                    {
                                                        results.Add(attribute.Name, result);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }      
                    }

                    template.AddHandler(Frame.NavigatingFromEvent, HandleNavigatingFrom);
                }

                void NavigatedFrom(object? sender, 
                    TemplatedControl template,
                    Func<Dictionary<string, object>> resultCallBack)
                {
                    async void HandleNavigatedFrom(object? _,
                        NavigationEventArgs args)
                    {
                        template.RemoveHandler(Frame.NavigatedFromEvent, HandleNavigatedFrom);
                        if (args.NavigationMode == NavigationMode.New)
                        {
                            NavigatedTo(sender, template);
                        }

                        Dictionary<string, object> results = resultCallBack.Invoke();
                        async Task DoNavigatedFromRoutineAsync(object? content)
                        {
                            if (content is not null)
                            {
                                if (content is INavigatedFrom navigatedFrom)
                                {
                                    await navigatedFrom.NavigatedFromAsync();
                                }

                                Type contentType = content.GetType();
                                if (contentType.GetInterfaces() is Type[] contracts)
                                {
                                    foreach (Type contract in contracts)
                                    {
                                        if (contract.Name == typeof(INavigatedTo<>).Name &&
                                            contract.GetGenericArguments() is { Length: 1 } arguments)
                                        {
                                            if (contentType.GetMethods().FirstOrDefault(x =>
                                                x.Name == "NavigatedToAsync" && 
                                                        x.GetCustomAttribute<NavigationParameterAttribute>()
                                                    is NavigationParameterAttribute attribute && results.ContainsKey(attribute.Name)) 
                                                is MethodInfo methodInfo)
                                            {
                                                if (methodInfo.GetCustomAttribute<NavigationParameterAttribute>()
                                                    is NavigationParameterAttribute attribute)
                                                {
                                                    if (results.TryGetValue(attribute.Name, out object? value))
                                                    {
                                                        await methodInfo.InvokeAsync(content, value);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (args.Source is TemplatedControl sourceTemplate)
                        {
                            if (sourceTemplate.DataContext is object content)
                            {
                                await DoNavigatedFromRoutineAsync(content);
                            }
                        }

                        if (sender is TemplatedControl senderTemplate)
                        {
                            if (senderTemplate.DataContext is object content)
                            {
                                await DoNavigatedFromRoutineAsync(content);
                            }
                        }
                        else
                        {
                            await DoNavigatedFromRoutineAsync(sender);
                        }
                    }

                    template.AddHandler(Frame.NavigatedFromEvent, HandleNavigatedFrom);
                }

                void NavigatedTo(object? sender, 
                    TemplatedControl template)
                {
                    async void HandleNavigatedTo(object? _, 
                        NavigationEventArgs args)
                    {
                        template.RemoveHandler(Frame.NavigatedToEvent, HandleNavigatedTo);
                        NavigatingFrom(sender, template);

                        if (template.DataContext is object content)
                        {
                            if (content is INavigatedTo navigatedTo)
                            {
                                await navigatedTo.NavigatedToAsync();
                            }
                        }

                        await publisher.Proxy.PublishAsync(new NavigationChanged<string>("sdfds"));
                    }

                    template.AddHandler(Frame.NavigatedToEvent, HandleNavigatedTo);
                }

                template.DataContext = args.ViewModel;
                binder.Bind(template);

                NavigatedTo(args.Sender, template);
                frame.NavigateFromObject(template);
            }
        }

        return Task.CompletedTask;
    }

    public Task Handle(NavigateBack<Frame> args,
        CancellationToken cancellationToken = default)
    {
        if (args.Context is Frame frame)
        {
            frame.GoBack();
        }

        return Task.CompletedTask;
    }
}
