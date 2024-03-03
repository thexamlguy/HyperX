using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Reolink;

public partial class LiveViewModel : 
    ObservableViewModel
{
    [ObservableProperty]
    private string colour;

    public LiveViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer,
        string colour) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        this.colour = colour;
    }
}
