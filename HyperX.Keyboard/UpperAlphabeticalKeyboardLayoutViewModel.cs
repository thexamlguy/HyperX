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

        Add<KeyboardKeyButtonViewModel>('A');
        Add<KeyboardKeyButtonViewModel>('B');
        Add<KeyboardKeyButtonViewModel>('C');
        Add<KeyboardKeyButtonViewModel>('D');
        Add<KeyboardKeyButtonViewModel>('E');
        Add<KeyboardKeyButtonViewModel>('F');
        Add<KeyboardKeyButtonViewModel>('G');
        Add<KeyboardKeyButtonViewModel>('H');
        Add<KeyboardKeyButtonViewModel>('I');
        Add<KeyboardKeyButtonViewModel>('J');
        Add<KeyboardKeyButtonViewModel>('K');
        Add<KeyboardKeyButtonViewModel>('L');
        Add<KeyboardKeyButtonViewModel>('M');
        Add<KeyboardKeyButtonViewModel>('N');
        Add<KeyboardKeyButtonViewModel>('O');
        Add<KeyboardKeyButtonViewModel>('P');
        Add<KeyboardKeyButtonViewModel>('Q');
        Add<KeyboardKeyButtonViewModel>('R');
        Add<KeyboardKeyButtonViewModel>('S');
        Add<KeyboardKeyButtonViewModel>('T');
        Add<KeyboardKeyButtonViewModel>('U');
        Add<KeyboardKeyButtonViewModel>('V');
        Add<KeyboardKeyButtonViewModel>('W');
        Add<KeyboardKeyButtonViewModel>('X');
        Add<KeyboardKeyButtonViewModel>('Y');
        Add<KeyboardKeyButtonViewModel>('Z');
    }

    public IViewModelTemplate Template { get; }
}
