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

        Add<KeyboardButtonViewModel>('A');
        Add<KeyboardButtonViewModel>('B');
        Add<KeyboardButtonViewModel>('C');
        Add<KeyboardButtonViewModel>('D');
        Add<KeyboardButtonViewModel>('E');
        Add<KeyboardButtonViewModel>('F');
        Add<KeyboardButtonViewModel>('G');
        Add<KeyboardButtonViewModel>('H');
        Add<KeyboardButtonViewModel>('I');
        Add<KeyboardButtonViewModel>('J');
        Add<KeyboardButtonViewModel>('K');
        Add<KeyboardButtonViewModel>('L');
        Add<KeyboardButtonViewModel>('M');
        Add<KeyboardButtonViewModel>('N');
        Add<KeyboardButtonViewModel>('O');
        Add<KeyboardButtonViewModel>('P');
        Add<KeyboardButtonViewModel>('Q');
        Add<KeyboardButtonViewModel>('R');
        Add<KeyboardButtonViewModel>('S');
        Add<KeyboardButtonViewModel>('T');
        Add<KeyboardButtonViewModel>('U');
        Add<KeyboardButtonViewModel>('V');
        Add<KeyboardButtonViewModel>('W');
        Add<KeyboardButtonViewModel>('X');
        Add<KeyboardButtonViewModel>('Y');
        Add<KeyboardButtonViewModel>('Z');
    }

    public IViewModelTemplate Template { get; }
}
