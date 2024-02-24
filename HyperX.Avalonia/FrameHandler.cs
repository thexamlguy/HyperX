using Avalonia.Controls.Primitives;
using FluentAvalonia.UI.Navigation;
using HyperX.UI.Controls.Avalonia;

namespace HyperX.Avalonia;

public class FrameHandler(IViewModelContentBinder binder) : 
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
                async void HandleNavigated(object sender, NavigationEventArgs args)
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
                            if (content.DataContext is INavigatingFrom navigatingFrom)
                            {
                                await navigatingFrom.NavigatingFromAsync();
                            }
                        }
                    }
                }

                content.DataContext = args.ViewModel;
                binder.Bind(content);

                frame.Navigating += HandleNavigating;
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
