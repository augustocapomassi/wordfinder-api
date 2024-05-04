using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WordFinder.Services.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddServices(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IWordFinderFactory, WordFinderFactory>();
        serviceCollection.AddSingleton<IWordFinderService, WordFinderService>();
    }
}
