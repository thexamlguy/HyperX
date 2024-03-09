namespace HyperX.Spotify;

public partial class SkipPreviousButtonViewModel :
    ObservableViewModel
{
    public SkipPreviousButtonViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}
