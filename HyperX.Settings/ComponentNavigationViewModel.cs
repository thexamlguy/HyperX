using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Settings;

public partial class ComponentNavigationViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer, 
    string text,
    string component) :
    NavigationViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer, text)
{
    [ObservableProperty]
    private string component = component;
}
