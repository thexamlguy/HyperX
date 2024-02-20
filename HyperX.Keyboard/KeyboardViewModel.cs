using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class KeyboardViewModel :
    ObservableCollectionViewModel<KeyboardLayoutViewModel>,
    INotificationHandler<Keyboard<char>>,
    INotificationHandler<Keyboard<Delete>>,
    INotificationHandler<Keyboard<Space>>,
    INotificationHandler<Keyboard<Previous>>,
    INotificationHandler<Keyboard<Next>>
{
    [ObservableProperty]
    private string text = "";

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

    public Task Handle(Keyboard<char> args, 
        CancellationToken cancellationToken = default)
    {
        if (args.Value is char value)
        {
            Text = Text.Insert(Position, $"{value}");
            Position = Position == Text.Length ? Position : Position + 1;
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Delete> args, 
        CancellationToken cancellationToken = default)
    {
        if (Text is { Length: > 0 } && Position > 0)
        {
            Text = Text.Remove(Position - 1, 1);

            int position = --Position;
            if (position >= 0 && position <= Text.Length)
            {
                Position = position;
            }
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Previous> args, 
        CancellationToken cancellationToken = default)
    {
        if (Text is { Length: > 0 })
        {
            int position = Position - 1;
            if (position >= 0 && position <= Text.Length)
            {
                Position = position;
            }
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Next> args, 
        CancellationToken cancellationToken = default)
    {
        if (Text is { Length: > 0 })
        {
            int position = Position + 1;
            if (position >= 0 && position <= Text.Length)
            {
                Position = position;
            }
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Space> args, 
        CancellationToken cancellationToken = default)
    {
        Text = Text.Insert(Position, " ");
        Position = Position == Text.Length ? Position : Position + 1;

        return Task.CompletedTask;
    }
}