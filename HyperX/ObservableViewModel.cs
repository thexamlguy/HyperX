using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX;

public class ObservableViewModel : 
    ObservableObject,
    IObservableViewModel,
    IInitializer
{
    private bool isInitialized;

    public ObservableViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer)
    {
        ServiceProvider = serviceProvider;
        ServiceFactory = serviceFactory;
        Publisher = publisher;
        Disposer = disposer;

        subscriber.Add(this);
    }

    public IDisposer Disposer { get; }

    public IPublisher Publisher { get; }

    public IServiceFactory ServiceFactory { get; }

    public IServiceProvider ServiceProvider { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Disposer.Dispose(this);
    }

    public virtual Task Initialize()
    {
        if (isInitialized)
        {
            return Task.CompletedTask;
        }

        isInitialized = true;

        return Task.CompletedTask;
    }
}
