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

        Add<KeyboardCharacterButtonViewModel>('1');
        Add<KeyboardCharacterButtonViewModel>('2');
        Add<KeyboardCharacterButtonViewModel>('3');
        Add<KeyboardCharacterButtonViewModel>('4');
        Add<KeyboardCharacterButtonViewModel>('5');
        Add<KeyboardCharacterButtonViewModel>('6');
        Add<KeyboardCharacterButtonViewModel>('7');
        Add<KeyboardCharacterButtonViewModel>('8');
        Add<KeyboardCharacterButtonViewModel>('9');
        Add<KeyboardCharacterButtonViewModel>('0');
    }

    public IViewModelTemplate Template { get; }
}
