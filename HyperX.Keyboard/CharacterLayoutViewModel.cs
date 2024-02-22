namespace HyperX.Keyboard;

public partial class CharacterLayoutViewModel :
    KeyboardLayoutViewModel
{
    public CharacterLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<LowerAlphabeticalLayoutNavigationViewModel>();
        Add<UpperAlphabeticalLayoutNavigationViewModel>();
        Add<NumericalLayoutNavigationViewModel>();
    }

    public IViewModelTemplate Template { get; }
}
