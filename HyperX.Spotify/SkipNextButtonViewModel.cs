namespace HyperX.Spotify;

public partial class SkipNextButtonViewModel :
    ObservableViewModel
{
    public SkipNextButtonViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}
