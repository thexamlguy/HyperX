namespace HyperX.Widgets.Avalonia;

public class WidgetsComponent :
    IComponent
{
    public IComponentBuilder Create()
    {
        return ComponentBuilder.Create()
            .AddConfiguration<WidgetsConfiguration>(args =>
            {
                args.Name = "Widgets";
                args.Description = "Widgets board";
                args.Layouts =
                [
                    new() {
                        new Widget
                        {
                            Name = "Spotify",
                            Component = "SpotifyComponent",
                            Row = 0,
                            Column = 0,
                            RowSpan = 2,
                            ColumnSpan = 2
                        }
                    },
                    new() {
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
                    }
                ];
            })
            .AddServices(services =>
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
}