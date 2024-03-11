using Microsoft.Extensions.DependencyInjection;

namespace HyperX.Settings;

public class ComponentHandler(IPublisher publisher,
    IComponentScopeProvider componentScopeProvider) :
    INotificationHandler<Enumerate<IComponentConfigurationViewModel>>
{
    public async Task Handle(Enumerate<IComponentConfigurationViewModel> args, 
        CancellationToken cancellationToken = default)
    {
        if (componentScopeProvider.Get($"{args.Key}") is IServiceProvider serviceProvider)
        {
            if (serviceProvider.GetService<IEnumerable<IComponentConfigurationViewModel>>() 
                is IEnumerable<IComponentConfigurationViewModel> viewModels)
            {
                foreach (IComponentConfigurationViewModel viewModel in viewModels)
                {
                    await publisher.PublishUI(new Create<IComponentConfigurationViewModel>(viewModel), args.Key,
                        cancellationToken);
                }
            }
        }
    }
}
