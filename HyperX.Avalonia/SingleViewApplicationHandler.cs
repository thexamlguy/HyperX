using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace HyperX.Avalonia;

public class SingleViewApplicationHandler(IViewModelContentBinder binder) :
    INavigateHandler<ISingleViewApplicationLifetime>
{
    public Task Handle(Navigate<ISingleViewApplicationLifetime> args,
        CancellationToken cancellationToken = default)
    {
        if (Application.Current?.ApplicationLifetime is
            ISingleViewApplicationLifetime lifeTime)
        {
            if (args.View is ContentControl content)
            {
                lifeTime.MainView = content;
                content.DataContext = args.ViewModel;

                binder.Bind(content);
            }
        }

        return Task.CompletedTask;
    }
}
