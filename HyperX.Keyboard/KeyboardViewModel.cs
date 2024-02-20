using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class KeyboardViewModel :
    ObservableCollectionViewModel<KeyboardLayoutViewModel>,
    INotificationHandler<Keyboard<Key>>
{
    [ObservableProperty]
    private string? text;

    [ObservableProperty]
    private int position;

    public KeyboardViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<KeyboardCharacterLayoutViewModel>();
        Add<KeyboardFunctionLayoutViewModel>();
    }

    public IViewModelTemplate Template { get; }

    public Task Handle(Keyboard<Key> args, 
        CancellationToken cancellationToken = default)
    {
        if (args.Value is Key value)
        {
            Text += value.Character;
            Position = Text.Length;
        }

        return Task.CompletedTask;
    }
}