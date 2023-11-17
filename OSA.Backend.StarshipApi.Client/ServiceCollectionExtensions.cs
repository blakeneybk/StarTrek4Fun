using Microsoft.Extensions.DependencyInjection;

namespace OSA.Backend.StarshipApi.Client;

public static class ServiceCollectionExtensions
{
    //make it easy for consumers to register the client services
    public static IServiceCollection AddStarshipApiClientService(this IServiceCollection services, Uri baseAddress)
    {
        // Ensure the baseAddress is not null
        if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress), "A valid base address must be provided.");

        services.AddHttpClient<IStarshipApiClientService, StarshipApiClientService>(client =>
        {
            client.BaseAddress = baseAddress;
        });

        return services;
    }
}