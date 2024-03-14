using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Widgets;

public partial class WidgetContainerViewModel : 
    ObservableViewModel
{
    [ObservableProperty]
    private int column;

    [ObservableProperty]
    private int columnSpan;

    [ObservableProperty]
    private string component;

    [ObservableProperty]
    private string route;

    [ObservableProperty]
    private int row;

    [ObservableProperty]
    private int rowSpan;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private bool isRouted;

    public WidgetContainerViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IContentTemplate template,
        int row,
        int column,
        int rowSpan,
        int columnSpan,
        string route,
        string component) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;
        Row = row;
        Column = column;
        RowSpan = rowSpan;
        ColumnSpan = columnSpan;
        Route = route;
        Name = route[(route.LastIndexOf('/') + 1)..] ?? route;
        Component = component;
    }

    public IContentTemplate Template { get; }
}