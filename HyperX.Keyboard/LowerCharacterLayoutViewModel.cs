namespace HyperX.Keyboard;

public class LowerCharacterLayoutViewModel : 
    KeyboardLayoutViewModel
{
    public LowerCharacterLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<CharacterButtonViewModel>('q');
        Add<CharacterButtonViewModel>('w');
        Add<CharacterButtonViewModel>('e');
        Add<CharacterButtonViewModel>('r');
        Add<CharacterButtonViewModel>('t');
        Add<CharacterButtonViewModel>('y');
        Add<CharacterButtonViewModel>('u');
        Add<CharacterButtonViewModel>('i');
        Add<CharacterButtonViewModel>('o');
        Add<CharacterButtonViewModel>('p');
        Add<CharacterButtonViewModel>('a');
        Add<CharacterButtonViewModel>('s');
        Add<CharacterButtonViewModel>('d');
        Add<CharacterButtonViewModel>('f');
        Add<CharacterButtonViewModel>('g');
        Add<CharacterButtonViewModel>('h');
        Add<CharacterButtonViewModel>('j');
        Add<CharacterButtonViewModel>('k');
        Add<CharacterButtonViewModel>('l');
        Add<CharacterButtonViewModel>('\'');
        Add<CharacterButtonViewModel>('z');
        Add<CharacterButtonViewModel>('x');
        Add<CharacterButtonViewModel>('c');
        Add<CharacterButtonViewModel>('v');
        Add<CharacterButtonViewModel>('b');
        Add<CharacterButtonViewModel>('n');
        Add<CharacterButtonViewModel>('m');
        Add<CharacterButtonViewModel>(',');
        Add<CharacterButtonViewModel>('.');
        Add<CharacterButtonViewModel>('?');
    }

    public IViewModelTemplate Template { get; }
}
