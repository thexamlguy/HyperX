using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace HyperX.Avalonia;

public class ClassicDesktopStyleApplicationHandler(IViewModelContentBinder binder) :
    INavigationHandler<IClassicDesktopStyleApplicationLifetime>
{
    public Task Handle(Navigate<IClassicDesktopStyleApplicationLifetime> args,
        CancellationToken cancellationToken = default)
    {
        if (Application.Current?.ApplicationLifetime is 
            IClassicDesktopStyleApplicationLifetime lifeTime)
        {
            if (args.View is Window window)
            {
                lifeTime.MainWindow = window;
                window.DataContext = args.ViewModel;

                binder.Bind(window, window);
            }
        }

        return Task.CompletedTask;
    }
}
