namespace HyperX.Keyboard;

public class NumericalKeyboardLayoutViewModel :
    KeyboardLayoutViewModel
{
    public NumericalKeyboardLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<KeyboardKeyButtonViewModel>('1');
        Add<KeyboardKeyButtonViewModel>('2');
        Add<KeyboardKeyButtonViewModel>('3');
        Add<KeyboardKeyButtonViewModel>('4');
        Add<KeyboardKeyButtonViewModel>('5');
        Add<KeyboardKeyButtonViewModel>('6');
        Add<KeyboardKeyButtonViewModel>('7');
        Add<KeyboardKeyButtonViewModel>('8');
        Add<KeyboardKeyButtonViewModel>('9');
        Add<KeyboardKeyButtonViewModel>('0');
    }

    public IViewModelTemplate Template { get; }
}
