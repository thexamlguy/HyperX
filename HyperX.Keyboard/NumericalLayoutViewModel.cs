namespace HyperX.Keyboard;

public class NumericalLayoutViewModel :
    KeyboardLayoutViewModel
{
    public NumericalLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IContentTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<CharacterButtonViewModel>('1');
        Add<CharacterButtonViewModel>('2');
        Add<CharacterButtonViewModel>('3');
        Add<CharacterButtonViewModel>('4');
        Add<CharacterButtonViewModel>('5');
        Add<CharacterButtonViewModel>('6');
        Add<CharacterButtonViewModel>('7');
        Add<CharacterButtonViewModel>('8');
        Add<CharacterButtonViewModel>('9');
        Add<CharacterButtonViewModel>('0');
    }

    public IContentTemplate Template { get; }
}
