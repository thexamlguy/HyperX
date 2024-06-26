﻿using Microsoft.Extensions.Hosting;
using Avalonia;
using Avalonia.Markup.Xaml;
using HyperX.Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using HyperX.Keyboard.Avalonia;
using HyperX.Spotify.Avalonia;
using HyperX.WiFi.Avalonia;
using HyperX.Widgets.Avalonia;
using HyperX.DateTime.Avalonia;
using HyperX.Reolink.Avalonia;
using HyperX.Settings.Avalonia;

namespace HyperX.Launcher.Avalonia;

public partial class App : 
    Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override async void OnFrameworkInitializationCompleted()
    {
        IHost? host = DefaultBuilder.Create()
            .ConfigureServices((context, services) =>
            {
                services.AddAvalonia();

                services.AddComponent<SettingsComponent>();
                services.AddComponent<KeyboardComponent>();
                services.AddComponent<WiFiComponent>();
                services.AddComponent<DateTimeComponent>();
                services.AddComponent<WidgetsComponent>();
                services.AddComponent<SpotifyComponent>();
                services.AddComponent<ReolinkComponent>();

                services.AddHandler<AppStartedHandler>();

                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                {
                    services.AddTemplate<MainWindowViewModel, MainWindow>("Shell");
                }

                services.AddTemplate<MainViewModel, MainView>("Main");
                services.AddTemplate<BackButtonViewModel, BackButtonView>("Back");
                services.AddTemplate<SettingsButtonViewModel, SettingsButtonView>("Settings");
            })
        .Build();

        await host.RunAsync();
    }
}
