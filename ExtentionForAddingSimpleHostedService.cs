using Microsoft.Extensions.DependencyInjection;

namespace SimpleHostedService;

public static class ExtensionForAddingSimpleHostedService
{
    /// <summary>
    /// Extension method for adding
    /// simplified hosted service
    /// </summary>
    /// <param name="serviceCollection">Service collection</param>
    /// <param name="executeTask">The task for execution</param>
    /// <returns></returns>
    public static IServiceCollection AddSimpleHostedService(this IServiceCollection serviceCollection,
        Func<CancellationToken, Task> executeTask)
    {
        serviceCollection.AddHostedService<SimplifiedHostedService>(sp => new SimplifiedHostedService(executeTask));
        return serviceCollection;
    }
}