namespace HyperX.Keyboard;

public class LowerAlphabeticalKeyboardLayoutViewModel : KeyboardLayoutViewModel
{
    public LowerAlphabeticalKeyboardLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<KeyboardCharacterButtonViewModel>('a');
        Add<KeyboardCharacterButtonViewModel>('b');
        Add<KeyboardCharacterButtonViewModel>('c');
        Add<KeyboardCharacterButtonViewModel>('d');
        Add<KeyboardCharacterButtonViewModel>('e');
        Add<KeyboardCharacterButtonViewModel>('f');
        Add<KeyboardCharacterButtonViewModel>('g');
        Add<KeyboardCharacterButtonViewModel>('h');
        Add<KeyboardCharacterButtonViewModel>('i');
        Add<KeyboardCharacterButtonViewModel>('j');
        Add<KeyboardCharacterButtonViewModel>('k');
        Add<KeyboardCharacterButtonViewModel>('l');
        Add<KeyboardCharacterButtonViewModel>('m');
        Add<KeyboardCharacterButtonViewModel>('n');
        Add<KeyboardCharacterButtonViewModel>('o');
        Add<KeyboardCharacterButtonViewModel>('p');
        Add<KeyboardCharacterButtonViewModel>('q');
        Add<KeyboardCharacterButtonViewModel>('r');
        Add<KeyboardCharacterButtonViewModel>('s');
        Add<KeyboardCharacterButtonViewModel>('t');
        Add<KeyboardCharacterButtonViewModel>('u');
        Add<KeyboardCharacterButtonViewModel>('v');
        Add<KeyboardCharacterButtonViewModel>('w');
        Add<KeyboardCharacterButtonViewModel>('x');
        Add<KeyboardCharacterButtonViewModel>('y');
        Add<KeyboardCharacterButtonViewModel>('z');
    }

    public IViewModelTemplate Template { get; }
}
