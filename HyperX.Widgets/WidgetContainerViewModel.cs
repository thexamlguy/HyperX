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
    private string name;

    [ObservableProperty]
    private int row;

    [ObservableProperty]
    private int rowSpan;

    [ObservableProperty]
    private string scope;

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
        string name,
        string scope) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;
        Row = row;
        Column = column;
        RowSpan = rowSpan;
        ColumnSpan = columnSpan;
        Name = name;
        Scope = scope;
    }

    public IViewModelTemplate Template { get; }
}