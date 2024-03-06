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
    private string name;

    [ObservableProperty]
    private object[]? parameters;
    [ObservableProperty]
    private int row;

    [ObservableProperty]
    private int rowSpan;

    public WidgetContainerViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template,
        int row,
        int column,
        int rowSpan,
        int columnSpan,
        string component,
        string name,
        object[]? parameters = null) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;
        Row = row;
        Column = column;
        RowSpan = rowSpan;
        ColumnSpan = columnSpan;
        Component = component;
        Name = name;
        Parameters = parameters;
    }

    public IViewModelTemplate Template { get; }
}