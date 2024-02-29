using System;

namespace HyperX.Launcher.Avalonia;

public partial class MainViewModel :
    ObservableCollectionViewModel<IDisposable>
{
    public MainViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
        Add<TestViewModel>();
    }

    public IViewModelTemplate Template { get; }
}
