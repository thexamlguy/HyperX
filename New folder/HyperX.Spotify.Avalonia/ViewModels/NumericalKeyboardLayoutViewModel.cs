using HyperX.Avalonia;
using System;

namespace HyperX.Spotify.Avalonia;

public class NumericalKeyboardLayoutViewModel :
    KeyboardLayoutViewModel
{
    public NumericalKeyboardLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<KeyboardButtonViewModel>('1');
        Add<KeyboardButtonViewModel>('2');
        Add<KeyboardButtonViewModel>('3');
        Add<KeyboardButtonViewModel>('4');
        Add<KeyboardButtonViewModel>('5');
        Add<KeyboardButtonViewModel>('6');
        Add<KeyboardButtonViewModel>('7');
        Add<KeyboardButtonViewModel>('8');
        Add<KeyboardButtonViewModel>('9');
        Add<KeyboardButtonViewModel>('0');
    }

    public IViewModelTemplate Template { get; }
}
