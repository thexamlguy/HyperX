using HyperX.UI.Controls.Avalonia;

namespace HyperX.Avalonia;

public class ContentDialogHandler : 
    INavigateHandler<ContentDialog>
{
    public async Task Handle(Navigate<ContentDialog> args,
        CancellationToken cancellationToken)
    {
        if (args.Context is ContentDialog contentDialog)
        {
            contentDialog.DataContext = args.Content;    
            async void HandleClosing(FluentAvalonia.UI.Controls.ContentDialog sender,
                 FluentAvalonia.UI.Controls.ContentDialogClosingEventArgs args)
            {
                if (args.Result == FluentAvalonia.UI.Controls.ContentDialogResult.Primary || 
                    args.Result == FluentAvalonia.UI.Controls.ContentDialogResult.Secondary)
                {
                    contentDialog.Closing -= HandleClosing;
                    if (contentDialog.DataContext is object content)
                    {
                        if (content is IConfirmNavigation confirmNavigation)
                        {
                            if (!await confirmNavigation.ConfirmNavigation())
                            {
                                args.Cancel = true;
                                contentDialog.Closing += HandleClosing;
                            }
                        }
                    }
                }
            }

            async void HandleOpened(FluentAvalonia.UI.Controls.ContentDialog sender,
                EventArgs args)
            {
                contentDialog.Opened -= HandleOpened;
                if (contentDialog.DataContext is object content)
                {
                    if (content is IInitializer initializer)
                    {
                        // A hack to wait for the dialog to finish loading up to make it appear more responsive
                        await Task.Delay(250);
                        await initializer.Initialize();
                    }
                }
            }
            
            contentDialog.Opened += HandleOpened;
            contentDialog.Closing += HandleClosing;

            await contentDialog.ShowAsync();
        }
    }
}