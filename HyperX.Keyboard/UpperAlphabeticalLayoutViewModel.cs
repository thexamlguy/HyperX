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

        Add<CharacterButtonViewModel>('A');
        Add<CharacterButtonViewModel>('B');
        Add<CharacterButtonViewModel>('C');
        Add<CharacterButtonViewModel>('D');
        Add<CharacterButtonViewModel>('E');
        Add<CharacterButtonViewModel>('F');
        Add<CharacterButtonViewModel>('G');
        Add<CharacterButtonViewModel>('H');
        Add<CharacterButtonViewModel>('I');
        Add<CharacterButtonViewModel>('J');
        Add<CharacterButtonViewModel>('K');
        Add<CharacterButtonViewModel>('L');
        Add<CharacterButtonViewModel>('M');
        Add<CharacterButtonViewModel>('N');
        Add<CharacterButtonViewModel>('O');
        Add<CharacterButtonViewModel>('P');
        Add<CharacterButtonViewModel>('Q');
        Add<CharacterButtonViewModel>('R');
        Add<CharacterButtonViewModel>('S');
        Add<CharacterButtonViewModel>('T');
        Add<CharacterButtonViewModel>('U');
        Add<CharacterButtonViewModel>('V');
        Add<CharacterButtonViewModel>('W');
        Add<CharacterButtonViewModel>('X');
        Add<CharacterButtonViewModel>('Y');
        Add<CharacterButtonViewModel>('Z');
    }

    public IViewModelTemplate Template { get; }
}
