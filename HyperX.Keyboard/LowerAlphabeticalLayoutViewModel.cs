namespace HyperX.Keyboard;

public class LowerAlphabeticalLayoutViewModel : KeyboardLayoutViewModel
{
    public LowerAlphabeticalLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<CharacterButtonViewModel>('a');
        Add<CharacterButtonViewModel>('b');
        Add<CharacterButtonViewModel>('c');
        Add<CharacterButtonViewModel>('d');
        Add<CharacterButtonViewModel>('e');
        Add<CharacterButtonViewModel>('f');
        Add<CharacterButtonViewModel>('g');
        Add<CharacterButtonViewModel>('h');
        Add<CharacterButtonViewModel>('i');
        Add<CharacterButtonViewModel>('j');
        Add<CharacterButtonViewModel>('k');
        Add<CharacterButtonViewModel>('l');
        Add<CharacterButtonViewModel>('m');
        Add<CharacterButtonViewModel>('n');
        Add<CharacterButtonViewModel>('o');
        Add<CharacterButtonViewModel>('p');
        Add<CharacterButtonViewModel>('q');
        Add<CharacterButtonViewModel>('r');
        Add<CharacterButtonViewModel>('s');
        Add<CharacterButtonViewModel>('t');
        Add<CharacterButtonViewModel>('u');
        Add<CharacterButtonViewModel>('v');
        Add<CharacterButtonViewModel>('w');
        Add<CharacterButtonViewModel>('x');
        Add<CharacterButtonViewModel>('y');
        Add<CharacterButtonViewModel>('z');
        Add<CharacterButtonViewModel>(',');
        Add<CharacterButtonViewModel>('\'');
        Add<CharacterButtonViewModel>('.');
        Add<CharacterButtonViewModel>('?');
    }

    public IViewModelTemplate Template { get; }
}
