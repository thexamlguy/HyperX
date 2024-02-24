using System;
using System.Threading.Tasks;

namespace HyperX.Launcher.Avalonia;

public class TestViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer), 
    IConfirmNavigation
{
    public Task<bool> ConfirmNavigationAsync()
    {
        return Task.FromResult(false);
    }
}
