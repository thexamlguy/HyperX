using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace HyperX.Avalonia;

public class SingleViewApplicationHandler(INavigationContext navigationContext) :
    INavigateHandler<ISingleViewApplicationLifetime>
{
    public Task Handle(Navigate<ISingleViewApplicationLifetime> args,
        CancellationToken cancellationToken = default)
    {
        if (Application.Current?.ApplicationLifetime is
            ISingleViewApplicationLifetime lifeTime)
        {
            if (args.Template is Control control)
            {
                lifeTime.MainView = control;
                control.DataContext = args.Content;

                navigationContext.Set(control);
            }
        }

        return Task.CompletedTask;
    }
}
