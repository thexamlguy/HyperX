namespace HyperX.Widgets.Avalonia;

public class WidgetsComponent :
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddConfiguration<WidgetsConfiguration>(args => {
                args.Add([
                    new Widget
                    {
                        Name = "Spotify",
                        Component = "SpotifyComponent",
                        Row = 0,
                        Column = 0,
                        RowSpan = 2,
                        ColumnSpan = 2
                    }
                ]);
                args.Add([
                    new Widget
                    {
                        Name = "Live",
                        Component = "ReolinkComponent",
                        Row = 0,
                        Column = 0,
                        RowSpan = 2,
                        ColumnSpan = 2,
                        Arguments = new Dictionary<string, object>
                        {
                            { "Colour", "Red" },
                            { "Test", 1 },
                        }
                    }
                ]);
            })
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<WidgetsViewModel,
                    WidgetsView>("Widgets");

                services.AddViewModelTemplate<WidgetLayoutViewModel,
                    WidgetLayoutView>();

                services.AddViewModelTemplate<WidgetContainerViewModel,
                    WidgetContainerView>();

                services.AddHandler<WidgetLayoutHandler>();
                services.AddHandler<WidgetContainerHandler>();
            });
}