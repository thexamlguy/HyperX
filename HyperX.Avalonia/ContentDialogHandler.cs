using HyperX.UI.Controls.Avalonia;

namespace HyperX.Avalonia;

public class ContentDialogHandler(IViewModelContentBinder binder) :
    INavigateHandler<ContentDialog>
{
    public async Task Handle(Navigate<ContentDialog> args,
        CancellationToken cancellationToken)
    {
        if (args.Context is ContentDialog contentDialog)
        {
            contentDialog.DataContext = args.ViewModel;
            await contentDialog.ShowAsync();
        }
    }
}