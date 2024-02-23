namespace HyperX.Keyboard;

public class UpperAlphabeticalLayoutViewModel : 
    KeyboardLayoutViewModel
{
    public UpperAlphabeticalLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<CharacterButtonViewModel>('Q');
        Add<CharacterButtonViewModel>('W');
        Add<CharacterButtonViewModel>('E');
        Add<CharacterButtonViewModel>('R');
        Add<CharacterButtonViewModel>('T');
        Add<CharacterButtonViewModel>('Y');
        Add<CharacterButtonViewModel>('U');
        Add<CharacterButtonViewModel>('I');
        Add<CharacterButtonViewModel>('O');
        Add<CharacterButtonViewModel>('P');
        Add<CharacterButtonViewModel>('A');
        Add<CharacterButtonViewModel>('S');
        Add<CharacterButtonViewModel>('D');
        Add<CharacterButtonViewModel>('F');
        Add<CharacterButtonViewModel>('G');
        Add<CharacterButtonViewModel>('H');
        Add<CharacterButtonViewModel>('J');
        Add<CharacterButtonViewModel>('K');
        Add<CharacterButtonViewModel>('L');
        Add<CharacterButtonViewModel>('\'');
        Add<CharacterButtonViewModel>('Z');
        Add<CharacterButtonViewModel>('X');
        Add<CharacterButtonViewModel>('C');
        Add<CharacterButtonViewModel>('V');
        Add<CharacterButtonViewModel>('B');
        Add<CharacterButtonViewModel>('N');
        Add<CharacterButtonViewModel>('M');
        Add<CharacterButtonViewModel>(',');
        Add<CharacterButtonViewModel>('.');
        Add<CharacterButtonViewModel>('?');
    }

    public IViewModelTemplate Template { get; }
}
