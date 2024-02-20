using CommunityToolkit.Mvvm.Input;

namespace HyperX.Keyboard;

public partial class KeyboardButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    public IRelayCommand ClickCommand => 
        new AsyncRelayCommand(OnClickAsync);

    protected virtual Task OnClickAsync() => 
        Task.CompletedTask;
}