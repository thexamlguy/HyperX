﻿namespace HyperX.WiFi.Avalonia;

public class WiFiComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddConfiguration<WiFiConfiguration>(args =>
            {
                args.Name = "WiFi";
                args.Description = "Manage WiFi connections";
            })
            .AddServices(services =>
            {
                services.AddTemplate<WiFiViewModel,
                    WiFiView>("WiFi");

                services.AddTemplate<ConnectedConnectionViewModel,
                    ConnectedConnectionView>();

                services.AddTemplate<SecuredConnectionViewModel,
                    SecuredConnectionView>();

                services.AddTemplate<OpenConnectionViewModel,
                    OpenConnectionView>();

                services.AddTemplate<ConnectionAuthenticationViewModel,
                    ConnectionAuthenticationView>("ConnectionAuthentication");

                services.AddTemplate<ConnectionInformationViewModel,
                    ConnectionInformationView>("ConnectionInformation");

                services.AddTemplate<ConnectionPasswordViewModel,
                    ConnectionPasswordView>();

                services.AddTemplate<ConnectViewModel,
                    ConnectView>();
            });
}