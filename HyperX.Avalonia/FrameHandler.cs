using Avalonia.Controls.Primitives;
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
                content.DataContext = args.ViewModel;
                frame.NavigateFromObject(content);

                binder.Bind(content, content);
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
