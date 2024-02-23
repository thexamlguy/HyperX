using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace HyperX.Avalonia;

public class ContentControlHandler(IViewModelContentBinder binder) : 
    INavigateHandler<ContentControl>
{
    public Task Handle(Navigate<ContentControl> args,
        CancellationToken cancellationToken)
    {
        if (args.Context is ContentControl contentControl)
        {
            if (args.View is TemplatedControl content)
            {
                contentControl.Content = content;
                contentControl.DataContext = args.ViewModel;

                binder.Bind(content, content);
            }
        }

        return Task.CompletedTask;
    }
}