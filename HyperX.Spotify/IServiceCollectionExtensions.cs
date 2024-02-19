using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSpotify(this IServiceCollection services)
    {
        services.AddHttpClient("Spotify", args =>
        {
            args.DefaultRequestHeaders.Add("Content-Type", "application/json");
        });

        return services;
    }
}