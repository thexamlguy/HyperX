using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class KeyboardViewModel :
    ObservableCollectionViewModel<KeyboardLayoutNavigationViewModel>,
    INotificationHandler<Create<KeyboardButtonInput>>
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

        Add<LowerAlphabeticalKeyboardLayoutNavigationViewModel>();
        Add<UpperAlphabeticalKeyboardLayoutNavigationViewModel>();
        Add<NumericalKeyboardLayoutNavigationViewModel>();
    }

    public IViewModelTemplate Template { get; }

    public Task Handle(Create<KeyboardButtonInput> args, 
        CancellationToken cancellationToken = default)
    {
        if (args.Value is KeyboardButtonInput value)
        {
            Text += value.Character;
            Position = Text.Length;
        }

        return Task.CompletedTask;
    }
}