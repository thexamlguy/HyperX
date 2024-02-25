using Avalonia.Controls.Primitives;
using FluentAvalonia.UI.Navigation;
using HyperX.UI.Controls.Avalonia;

namespace HyperX.Avalonia;

public class FrameHandler(IViewModelContentBinder binder, 
    IMediator mediator) : 
    INavigateHandler<Frame>,
    INavigateBackHandler<Frame>
{
    public Task Handle(Navigate<Frame> args,
        CancellationToken cancellationToken)
    {
        if (args.Context is Frame frame)
        {
            frame.NavigationPageFactory ??= new NavigationPageFactory();
            if (args.View is TemplatedControl content)
            {
                void Navigated(Frame frame)
                {
                    async void HandleNavigated(object sender,
                        NavigationEventArgs args)
                    {
                        frame.Navigated -= HandleNavigated;
                        if (frame.Content is TemplatedControl content)
                        {
                            if (content.DataContext is INavigatedTo navigatedTo)
                            {
                                await navigatedTo.NavigatedToAsync();
                            }
                        }
                    }

                    frame.Navigated += HandleNavigated;
                }

                void Navigating(object? sender,
                    Frame frame)
                {
                    async void HandleNavigating(object _,
                         NavigatingCancelEventArgs args)
                    {
                        frame.Navigating -= HandleNavigating;
                        async Task NavigationRoutineAsync(object? context)
                        {
                            if (context is TemplatedControl templated)
                            {
                                if (templated.DataContext is object content)
                                {
                                    if (content is IConfirmNavigation confirmNavigation &&
                                        !await confirmNavigation.ConfirmNavigationAsync())
                                    {
                                        args.Cancel = true;
                                    }
                                    else
                                    {
                                        await mediator.SendAsync(new NavigatingFrom(content),
                                            cancellationToken);
                                    }
                                }
                            }
                        }

                        await NavigationRoutineAsync(frame.Content);

                        if (frame.Content is not null 
                            && frame.Content != sender 
                            && frame != sender)
                        {
                            await NavigationRoutineAsync(sender);
                        }

                        if (!args.Cancel)
                        {
                            Navigated(frame);
                        }
                        else
                        {
                            frame.Navigating += HandleNavigating;
                        }
                    }

                    frame.Navigating += HandleNavigating;
                }

                content.DataContext = args.ViewModel;
                binder.Bind(content);

                Navigating(args.Sender, frame);
                frame.NavigateFromObject(content);
            }
        }

        return Task.CompletedTask;
    }

    public Task Handle(NavigateBack<Frame> args,
        CancellationToken cancellationToken = default)
    {
        if (args.Context is Frame frame)
        {
            async void HandleNavigated(object sender, NavigationEventArgs args)
            {
                frame.Navigated -= HandleNavigated;
                if (frame.Content is TemplatedControl content)
                {
                    if (content.DataContext is INavigatedFrom navigatedFrom) 
                    {
                        await navigatedFrom.NavigatedFromAsync();
                    }
                }
            }

            async void HandleNavigating(object sender, NavigatingCancelEventArgs args)
            {
                frame.Navigating -= HandleNavigating;
                if (frame.Content is TemplatedControl content)
                {
                    if (content.DataContext is IConfirmNavigation confirmNavigation &&
                        !await confirmNavigation.ConfirmNavigationAsync())
                    {
                        args.Cancel = true;
                    }
                    else
                    {
                        frame.Navigated += HandleNavigated;
                    }
                }
            }

            frame.Navigating += HandleNavigating;
            frame.GoBack();
        }

        return Task.CompletedTask;
    }
}
