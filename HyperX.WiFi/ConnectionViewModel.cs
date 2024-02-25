using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.WiFi;

public partial class ConnectionViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    string name) :
    ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private string name = name;
}
