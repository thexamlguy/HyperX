using System;

namespace HyperX.Spotify.Avalonia;

public class UpperAlphabeticalKeyboardLayoutNavigationViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    KeyboardLayoutNavigationViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer);