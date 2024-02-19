using HyperX.UI.Controls.Avalonia;

namespace HyperX.Avalonia;

public class FrameHandler(IViewModelContentBinder binder) : 
    INavigationHandler<Frame>
{
    public Task Handle(Navigate<Frame> args,
        CancellationToken cancellationToken)
    {
        //if (args.Context is ContentControl contentControl)
        //{
        //    if (args.View is TemplatedControl content)
        //    {
        //        contentControl.Content = content;
        //        contentControl.DataContext = args.ViewModel;

        //        binder.Bind(content, content);
        //    }
        //}

        return Task.CompletedTask;
    }
}
