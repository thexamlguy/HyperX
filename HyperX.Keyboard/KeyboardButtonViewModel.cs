using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HyperX.Keyboard;

public partial class KeyboardButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    char character) : 
    ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private char character = character;

    public IRelayCommand ClickCommand => new AsyncRelayCommand(async () => 
        await Publisher.PublishUIAsync(new Create<KeyboardButtonInput>(new KeyboardButtonInput(Character))));
}
