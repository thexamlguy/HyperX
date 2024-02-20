namespace HyperX.Keyboard;

public partial class KeyboardCharacterLayoutViewModel :
    KeyboardLayoutViewModel
{
    public KeyboardCharacterLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<LowerAlphabeticalKeyboardLayoutNavigationViewModel>();
        Add<UpperAlphabeticalKeyboardLayoutNavigationViewModel>();
        Add<NumericalKeyboardLayoutNavigationViewModel>();
    }

    public IViewModelTemplate Template { get; }
}
