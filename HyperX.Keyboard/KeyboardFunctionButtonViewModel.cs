
using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class KeyboardFunctionButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    int index,
    Func<Task> function) :
    KeyboardButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    private readonly Func<Task> function = function;

    [ObservableProperty]
    private int index = index;

    protected override async Task OnClickAsync() => await function();
}
