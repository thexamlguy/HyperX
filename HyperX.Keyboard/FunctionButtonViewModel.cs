
using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class FunctionButtonViewModel :
    KeyboardButtonViewModel
{
    private readonly Func<Task>? function;

    [ObservableProperty]
    private int column;

    public FunctionButtonViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        int column,
        Func<Task>? function = default) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Column = column;
        this.function = function;
    }

    public FunctionButtonViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        int column) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Column = column;
    }

    protected override async Task OnClickAsync()
    {
        if (function is not null)
        {
            await function();
        }
    }
}
