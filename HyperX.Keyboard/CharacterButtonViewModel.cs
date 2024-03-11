using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class CharacterButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    char character) :
    CommandViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private char character = character;

    protected override async Task InvokeAsync() =>
        await Publisher.PublishUI(new Keyboard<char>(Character));
}
