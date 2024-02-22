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

        Add<CharacterLayoutViewModel>();
        Add<FunctionLayoutViewModel>();
    }

    public IViewModelTemplate Template { get; }

    public Task Handle(Keyboard<char> args, 
        CancellationToken cancellationToken = default)
    {
        if (args.Value is char value)
        {
            InsertCharacter(value);
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Delete> args,
        CancellationToken cancellationToken = default)
    {
        if (Text.Length > 0 && Position > 0)
        {
            Text = Text.Remove(Position - 1, 1);
            MoveCursorLeft();
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Previous> args, 
        CancellationToken cancellationToken = default)
    {
        if (Text.Length > 0)
        {
            MoveCursorLeft();
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Next> args,
        CancellationToken cancellationToken = default)
    {
        if (Text.Length > 0)
        {
            MoveCursorRight();
        }

        return Task.CompletedTask;
    }

    public Task Handle(Keyboard<Space> args, 
        CancellationToken cancellationToken = default)
    {
        InsertCharacter(' ');
        return Task.CompletedTask;
    }

    private void InsertCharacter(char character)
    {
        Text = Text.Insert(Position, character.ToString());
        MoveCursorRight();
    }

    private void MoveCursorLeft() => 
        Position = Math.Max(Position - 1, 0);

    private void MoveCursorRight() => 
        Position = Math.Min(Position + 1, Text.Length);
}