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

        Add<KeyboardButtonViewModel>('a');
        Add<KeyboardButtonViewModel>('b');
        Add<KeyboardButtonViewModel>('c');
        Add<KeyboardButtonViewModel>('d');
        Add<KeyboardButtonViewModel>('e');
        Add<KeyboardButtonViewModel>('f');
        Add<KeyboardButtonViewModel>('g');
        Add<KeyboardButtonViewModel>('h');
        Add<KeyboardButtonViewModel>('i');
        Add<KeyboardButtonViewModel>('j');
        Add<KeyboardButtonViewModel>('k');
        Add<KeyboardButtonViewModel>('l');
        Add<KeyboardButtonViewModel>('m');
        Add<KeyboardButtonViewModel>('n');
        Add<KeyboardButtonViewModel>('o');
        Add<KeyboardButtonViewModel>('p');
        Add<KeyboardButtonViewModel>('q');
        Add<KeyboardButtonViewModel>('r');
        Add<KeyboardButtonViewModel>('s');
        Add<KeyboardButtonViewModel>('t');
        Add<KeyboardButtonViewModel>('u');
        Add<KeyboardButtonViewModel>('v');
        Add<KeyboardButtonViewModel>('w');
        Add<KeyboardButtonViewModel>('x');
        Add<KeyboardButtonViewModel>('y');
        Add<KeyboardButtonViewModel>('z');
    }

    public IViewModelTemplate Template { get; }
}
