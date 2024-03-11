namespace HyperX.Keyboard;

public partial class CharacterLayoutViewModel :
    KeyboardLayoutViewModel
{
    public CharacterLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer,
        IContentTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;
    }

    public IContentTemplate Template { get; }
}
