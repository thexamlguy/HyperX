using Microsoft.Extensions.Hosting;
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
                services.AddComponent<DateTimeComponent>();
                services.AddComponent<WidgetsComponent>();
                services.AddComponent<SpotifyComponent>();
                services.AddComponent<ReolinkComponent>();

                services.AddHandler<AppStartedHandler>();

                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                {
                    services.AddViewModelTemplate<MainWindowViewModel, MainWindow>("Shell");
                }

                services.AddViewModelTemplate<MainViewModel, MainView>("Main");
                services.AddViewModelTemplate<BackButtonViewModel, BackButtonView>();

                services.AddViewModelTemplate<TestViewModel, TestView>();

            })
        .Build();

        await host.RunAsync();
    }
}
