﻿namespace HyperX.Widgets;

public class WidgetContainerHandler(IPublisher publisher,
    IServiceFactory factory,
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
                            if (factory.Create<WidgetContainerViewModel>(Guid.NewGuid().ToString(), widget.Component, 0, 0, 1, 1)
                                is WidgetContainerViewModel item)
                            {
                                await publisher.PublishUIAsync(new Create<WidgetContainerViewModel>(item),
                                    args.Key, cancellationToken);
                            }
                        }
                    }
                }
            }
        }
    }
}