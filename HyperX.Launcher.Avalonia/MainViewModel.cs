using System;

namespace HyperX.Launcher.Avalonia;

public partial class MainViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    IViewModelTemplate template) :
    ObservableCollectionViewModel<IDisposable>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    public IViewModelTemplate Template => template;
}
