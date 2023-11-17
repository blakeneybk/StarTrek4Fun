using Microsoft.Extensions.DependencyInjection;

namespace OSA.Backend.CharacterApi.Client;

public static class ServiceCollectionExtensions
{
    //make it easy for consumers to register the client services
    public static IServiceCollection AddCharacterApiClientService(this IServiceCollection services, Uri baseAddress)
    {
        // Ensure the baseAddress is not null
        if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress), "A valid base address must be provided.");

        services.AddHttpClient<ICharacterApiClientService, CharacterApiClientService>(client =>
        {
            client.BaseAddress = baseAddress;
        });

        return services;
    }
}