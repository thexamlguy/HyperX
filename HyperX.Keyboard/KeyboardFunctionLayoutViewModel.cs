namespace HyperX.Keyboard;

public partial class KeyboardFunctionLayoutViewModel :
    KeyboardLayoutViewModel
{
    public KeyboardFunctionLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<KeyboardDeleteButtonViewModel>(0, async () => await Publisher.PublishUIAsync(new Keyboard<Delete>()));
        Add<KeyboardSpaceButtonViewModel>(1, async () => await Publisher.PublishUIAsync(new Keyboard<Space>()));
        Add<KeyboardPreviousButtonViewModel>(2, async () => await Publisher.PublishUIAsync(new Keyboard<Previous>()));
        Add<KeyboardNextButtonViewModel>(3, async () => await Publisher.PublishUIAsync(new Keyboard<Next>()));
    }

    public IViewModelTemplate Template { get; }
}
