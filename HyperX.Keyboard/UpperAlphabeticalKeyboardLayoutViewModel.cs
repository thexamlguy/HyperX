namespace HyperX.Keyboard;

public class UpperAlphabeticalKeyboardLayoutViewModel : 
    KeyboardLayoutViewModel
{
    public UpperAlphabeticalKeyboardLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<KeyboardCharacterButtonViewModel>('A');
        Add<KeyboardCharacterButtonViewModel>('B');
        Add<KeyboardCharacterButtonViewModel>('C');
        Add<KeyboardCharacterButtonViewModel>('D');
        Add<KeyboardCharacterButtonViewModel>('E');
        Add<KeyboardCharacterButtonViewModel>('F');
        Add<KeyboardCharacterButtonViewModel>('G');
        Add<KeyboardCharacterButtonViewModel>('H');
        Add<KeyboardCharacterButtonViewModel>('I');
        Add<KeyboardCharacterButtonViewModel>('J');
        Add<KeyboardCharacterButtonViewModel>('K');
        Add<KeyboardCharacterButtonViewModel>('L');
        Add<KeyboardCharacterButtonViewModel>('M');
        Add<KeyboardCharacterButtonViewModel>('N');
        Add<KeyboardCharacterButtonViewModel>('O');
        Add<KeyboardCharacterButtonViewModel>('P');
        Add<KeyboardCharacterButtonViewModel>('Q');
        Add<KeyboardCharacterButtonViewModel>('R');
        Add<KeyboardCharacterButtonViewModel>('S');
        Add<KeyboardCharacterButtonViewModel>('T');
        Add<KeyboardCharacterButtonViewModel>('U');
        Add<KeyboardCharacterButtonViewModel>('V');
        Add<KeyboardCharacterButtonViewModel>('W');
        Add<KeyboardCharacterButtonViewModel>('X');
        Add<KeyboardCharacterButtonViewModel>('Y');
        Add<KeyboardCharacterButtonViewModel>('Z');
    }

    public IViewModelTemplate Template { get; }
}
