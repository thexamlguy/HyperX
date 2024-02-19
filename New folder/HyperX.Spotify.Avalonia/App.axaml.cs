using Microsoft.Extensions.Hosting;
using Avalonia;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Controls.ApplicationLifetimes;

namespace HyperX.Spotify.Avalonia;

public partial class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override async void OnFrameworkInitializationCompleted()
    {
        IHost? host = HyperXBuilder.Create()
            .ConfigureServices((context, services) =>
            {
                services.AddAvalonia();

                services.AddHandler<AppStartedHandler>();
                services.AddHostedService<AuthenticationService>();

                services.AddConfiguration<SpotifyConfiguration>(args => 
                {
                    args.Port = 5543;
                    args.CallbackUrl = "??";             
                });

                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                {
                    services.AddContentTemplate<MainViewModel, MainWindow>("Shell");
                }

                services.AddContentTemplate<MainViewModel, MainView>("Main");
                services.AddContentTemplate<WelcomeViewModel, WelcomeView>("Welcome");

                services.AddContentTemplate<KeyboardViewModel, KeyboardView>("Keyboard");
                services.AddContentTemplate<KeyboardButtonViewModel, KeyboardButtonView>();

                services.AddContentTemplate<LowerAlphabeticalKeyboardLayoutNavigationViewModel, LowerAlphabeticalKeyboardLayoutNavigationView>();
                services.AddContentTemplate<LowerAlphabeticalKeyboardLayoutViewModel, LowerAlphabeticalKeyboardLayoutView>("LowerAlphabeticalKeyboardLayout");

                services.AddContentTemplate<UpperAlphabeticalKeyboardLayoutNavigationViewModel, UpperAlphabeticalKeyboardLayoutNavigationView>();
                services.AddContentTemplate<UpperAlphabeticalKeyboardLayoutViewModel, UpperAlphabeticalKeyboardLayoutView>("UpperAlphabeticalKeyboardLayout");

                services.AddContentTemplate<NumericalKeyboardLayoutNavigationViewModel, NumericalKeyboardLayoutNavigationView>();
                services.AddContentTemplate<NumericalKeyboardLayoutViewModel, NumericalKeyboardLayoutView>("NumericalKeyboardLayout");

                services.AddContentTemplate<ConnectViewModel, ConnectView>("Connect");
            })
        .Build();

        await host.RunAsync();
    }
}
