namespace HyperX.WiFi.Avalonia;

public class WiFiComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        DictionaryStringObjectJsonConverter.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<WiFiViewModel,
                    WiFiView>("WiFi");

                services.AddViewModelTemplate<ConnectedConnectionViewModel,
                    ConnectedConnectionView>();

                services.AddViewModelTemplate<SecuredConnectionViewModel,
                    SecuredConnectionView>();

                services.AddViewModelTemplate<OpenConnectionViewModel,
                    OpenConnectionView>();

                services.AddViewModelTemplate<ConnectionAuthenticationViewModel,
                    ConnectionAuthenticationView>("ConnectionAuthentication");

                services.AddViewModelTemplate<ConnectionInformationViewModel,
                    ConnectionInformationView>("ConnectionInformation");

                services.AddViewModelTemplate<ConnectionPasswordViewModel,
                    ConnectionPasswordView>();

                services.AddViewModelTemplate<ConnectViewModel,
                    ConnectView>();
            });
}