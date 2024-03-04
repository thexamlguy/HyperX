using System;

namespace HyperX.Launcher.Avalonia;

public class HeaderViewModel :
    ObservableCollectionViewModel<IDisposable>
{
    public HeaderViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}
