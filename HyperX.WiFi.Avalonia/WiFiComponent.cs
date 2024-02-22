using HyperX.WiFi;
using HyperX.WiFi.Avalonia;

namespace HyperX.Keyboard.Avalonia;

[ViewModelTemplateRoot("WiFi")]
public class WiFiComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<WiFiViewModel,
                    WiFiView>("WiFi");

                services.AddViewModelTemplate<WiFiConnectionViewModel,
                    WiFiConnectionView>();

                services.AddViewModelTemplate<WiFiConnectionInformationViewModel,
                    WiFiConnectionInformationView>("WiFiConnectionInformation");
            });
}