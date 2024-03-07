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
    private object content;

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
        object content) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;
        Row = row;
        Column = column;
        RowSpan = rowSpan;
        ColumnSpan = columnSpan;
        Content = content;
    }

    public IViewModelTemplate Template { get; }
}