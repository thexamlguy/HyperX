﻿using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Text;

namespace HyperX.Spotify;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSpotify(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<>), typeof(SpotifyPipeline<>));

        services.AddHandler<AuthenticationHandler>();
        services.AddHandler<AccessGrantedHandler>();
        services.AddHandler<AccessRevokedHandler>();

        services.AddHandler<PlayHandler>();

        services.AddHttpClient("Account", (provider, args) =>
        {
            SpotifyConfiguration configuration = provider.GetRequiredService<SpotifyConfiguration>();

            args.BaseAddress = new Uri(configuration.AccountUrl);
            args.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration.ClientId}:{configuration.ClientSecret}")));
        });

        services.AddHttpClient("Spotify", (provider, args) =>
        {
            SpotifyConfiguration configuration = provider.GetRequiredService<SpotifyConfiguration>();

            args.BaseAddress = new Uri(configuration.SpotifyUrl);
            args.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.Token);
        });

        return services;
    }
}