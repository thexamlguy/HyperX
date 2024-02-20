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

        Add<KeyboardKeyButtonViewModel>('a');
        Add<KeyboardKeyButtonViewModel>('b');
        Add<KeyboardKeyButtonViewModel>('c');
        Add<KeyboardKeyButtonViewModel>('d');
        Add<KeyboardKeyButtonViewModel>('e');
        Add<KeyboardKeyButtonViewModel>('f');
        Add<KeyboardKeyButtonViewModel>('g');
        Add<KeyboardKeyButtonViewModel>('h');
        Add<KeyboardKeyButtonViewModel>('i');
        Add<KeyboardKeyButtonViewModel>('j');
        Add<KeyboardKeyButtonViewModel>('k');
        Add<KeyboardKeyButtonViewModel>('l');
        Add<KeyboardKeyButtonViewModel>('m');
        Add<KeyboardKeyButtonViewModel>('n');
        Add<KeyboardKeyButtonViewModel>('o');
        Add<KeyboardKeyButtonViewModel>('p');
        Add<KeyboardKeyButtonViewModel>('q');
        Add<KeyboardKeyButtonViewModel>('r');
        Add<KeyboardKeyButtonViewModel>('s');
        Add<KeyboardKeyButtonViewModel>('t');
        Add<KeyboardKeyButtonViewModel>('u');
        Add<KeyboardKeyButtonViewModel>('v');
        Add<KeyboardKeyButtonViewModel>('w');
        Add<KeyboardKeyButtonViewModel>('x');
        Add<KeyboardKeyButtonViewModel>('y');
        Add<KeyboardKeyButtonViewModel>('z');
    }

    public IViewModelTemplate Template { get; }
}
