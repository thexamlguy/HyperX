using Microsoft.Extensions.Hosting;
using Avalonia;
using Avalonia.Markup.Xaml;
using HyperX.Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using HyperX.Keyboard.Avalonia;
using HyperX.Spotify.Avalonia;
using HyperX.WiFi.Avalonia;

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

                services.AddComponent<KeyboardComponent>();
                services.AddComponent<WiFiComponent>();
                services.AddComponent<SpotifyComponent>();

                services.AddHandler<AppStartedHandler>();

                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                {
                    services.AddViewModelTemplate<MainViewModel, MainWindow>("Shell");
                }

                services.AddViewModelTemplate<MainViewModel, MainView>("Main");
                services.AddViewModelTemplate<TestViewModel, TestView>("Test");

            })
        .Build();

        await host.RunAsync();
    }
}
