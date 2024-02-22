namespace HyperX.Keyboard;

public partial class FunctionLayoutViewModel :
    KeyboardLayoutViewModel
{
    public FunctionLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<DeleteButtonViewModel>(0, async () => await Publisher.PublishUIAsync(new Keyboard<Delete>()));
        Add<SpaceButtonViewModel>(1, async () => await Publisher.PublishUIAsync(new Keyboard<Space>()));
        Add<PreviousButtonViewModel>(2, async () => await Publisher.PublishUIAsync(new Keyboard<Previous>()));
        Add<NextButtonViewModel>(3, async () => await Publisher.PublishUIAsync(new Keyboard<Next>()));
    }

    public IViewModelTemplate Template { get; }
}
