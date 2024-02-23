
using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class FunctionButtonViewModel :
    KeyboardButtonViewModel
{
    private readonly Func<Task>? function;

    [ObservableProperty]
    private int index;

    public FunctionButtonViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        int index,
        Func<Task>? function = default) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Index = index;
        this.function = function;
    }

    public FunctionButtonViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        int index) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Index = index;
    }

    protected override async Task OnClickAsync()
    {
        if (function is not null)
        {
            await function();
        }
    }
}
