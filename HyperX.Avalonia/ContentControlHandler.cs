using Avalonia.Controls;
using Avalonia.Interactivity;

namespace HyperX.Avalonia;

public class ContentControlHandler(INavigationContext navigationContext) : 
    INavigateHandler<ContentControl>
{
    public Task Handle(Navigate<ContentControl> args,
        CancellationToken cancellationToken)
    {
        if (args.Context is ContentControl contentControl)
        {
            if (args.Template is Control control)
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
                    }
                }

                control.Loaded += HandleLoaded;

                contentControl.Content = control;
                contentControl.DataContext = args.Content;

                navigationContext.Set(control);
            }
        }

        return Task.CompletedTask;
    }
}
