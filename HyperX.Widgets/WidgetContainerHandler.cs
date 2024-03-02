using Microsoft.Extensions.DependencyInjection;

namespace HyperX.Widgets;

public class WidgetContainerHandler(IPublisher publisher,
    IServiceFactory fac,
    IComponentScopeProvider componentScopeProvider,
    WidgetsConfiguration configuration) :
    INotificationHandler<Enumerate<WidgetContainerViewModel>>
{
    public async Task Handle(Enumerate<WidgetContainerViewModel> args,
        CancellationToken cancellationToken)
    {
        if (args.Key is string key)
        {
            int colonIndex = key.LastIndexOf(':');
            if (colonIndex >= 0 && colonIndex < key.Length - 1)
            {
                string indexString = key[(colonIndex + 1)..];
                if (int.TryParse(indexString, out int index) && index >= 0 && index < configuration.Count)
                {
                    if (configuration[index] is WidgetLayout widgetLayout)
                    {
                        foreach (Widget widget in widgetLayout)
                        {
                            IServiceProvider? serviceProvider = 
                                componentScopeProvider.Get(widget.Component);

                            IViewModelTemplateProvider? viewModelTemplateProvider = 
                                serviceProvider?.GetService<IViewModelTemplateProvider>();

                            IViewModelTemplateDescriptor? viewModelTemplateDescriptor =
                                viewModelTemplateProvider?.Get(widget.Name);

                            IServiceFactory? serviceFactory = 
                                serviceProvider?.GetService<IServiceFactory>();

                            if (serviceFactory is not null && viewModelTemplateDescriptor is not null)
                            {
                                if (fac.Create<WidgetContainerViewModel>(widget.Row, widget.Column,
                                    widget.RowSpan, widget.ColumnSpan, viewModelTemplateDescriptor.GetViewModel())
                                    is WidgetContainerViewModel widgetContainerViewModel)
                                {
                                    await publisher.PublishUIAsync(new Create<WidgetContainerViewModel>(widgetContainerViewModel),
                                        args.Key, cancellationToken);
                                }                             
                            }
                        }
                    }
                }
            }
        }
    }
}