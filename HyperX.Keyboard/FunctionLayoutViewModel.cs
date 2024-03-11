namespace HyperX.Keyboard;

public partial class FunctionLayoutViewModel :
    KeyboardLayoutViewModel
{
    public FunctionLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer,
        IContentTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<ShiftButtonViewModel>(0);
        Add<SpaceButtonViewModel>(1, async () => await Publisher.PublishUI(new Keyboard<Space>()));
        Add<DeleteButtonViewModel>(2, async () => await Publisher.PublishUI(new Keyboard<Delete>()));
        Add<PreviousButtonViewModel>(3, async () => await Publisher.PublishUI(new Keyboard<Previous>()));
        Add<NextButtonViewModel>(4, async () => await Publisher.PublishUI(new Keyboard<Next>()));
        Add<EnterButtonViewModel>(5);
    }

    public IContentTemplate Template { get; }
}
