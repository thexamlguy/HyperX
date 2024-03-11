using System;

namespace HyperX.Launcher.Avalonia;

public partial class MainViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    IContentTemplate template) :
    ObservableCollectionViewModel<IDisposable>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    public IContentTemplate Template => template;
}
