using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Keyboard;

public partial class KeyboardKeyButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    char character) :
    KeyboardButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private char character = character;

    protected override async Task OnClickAsync() =>
        await Publisher.PublishUIAsync(new Keyboard<Key>(new Key(Character)));
}
