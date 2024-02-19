using System;

namespace HyperX.Spotify.Avalonia;

public class WelcomeViewModel :
    ObservableViewModel
{
    public WelcomeViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}
