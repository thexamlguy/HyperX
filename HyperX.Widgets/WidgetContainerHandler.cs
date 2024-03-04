using Microsoft.Extensions.DependencyInjection;

namespace HyperX.Widgets;

public class WidgetContainerHandler(IPublisher publisher,
    IServiceFactory serviceFactory,
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
                if (int.TryParse(indexString, out int index) && index >= 0 && index < configuration.Layouts.Count)
                {
                    if (configuration.Layouts[index] is WidgetLayout widgetLayout)
                    {
                        foreach (Widget widget in widgetLayout)
                        {
                            IServiceProvider? serviceProvider = 
                                componentScopeProvider.Get(widget.Component);

                            IViewModelTemplateProvider? viewModelTemplateProvider = 
                                serviceProvider?.GetService<IViewModelTemplateProvider>();

                            IViewModelTemplateDescriptor? viewModelTemplateDescriptor =
                                viewModelTemplateProvider?.Get(widget.Name);

                            if (serviceFactory is not null && viewModelTemplateDescriptor is not null)
                            {
                                Dictionary<string, object> arguments = new(widget.Arguments,
                                                       StringComparer.InvariantCultureIgnoreCase);

                                object?[]? parameters = viewModelTemplateDescriptor.ViewModelType
                                    .GetConstructors()
                                    .FirstOrDefault()?
                                    .GetParameters()
                                    .Select(parameter => parameter?.Name != null && arguments
                                        .TryGetValue(parameter.Name, out object? argument) ? argument : default)
                                    .Where(argument => argument != null)
                                    .ToArray();

                                if (serviceFactory.Create<WidgetContainerViewModel>(widget.Row, widget.Column,
                                    widget.RowSpan, widget.ColumnSpan, viewModelTemplateDescriptor.GetViewModel(parameters))
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