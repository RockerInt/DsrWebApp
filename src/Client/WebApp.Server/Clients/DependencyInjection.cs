using WebApp.Server.Config;
using WebApp.Server.Services;
using WebApp.Server.Resilience;
using Microsoft.Extensions.Logging;

namespace WebApp.Server.Clients;

/// <summary>
/// Provides extension methods for dependency injection of client services.
/// </summary>
public static class DependecyInjection
{
    /// <summary>
    /// Adds clients-specific services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> for retrieving settings.</param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        ILogger logger = services.BuildServiceProvider().GetRequiredService<ILoggerFactory>().CreateLogger("HttpPoliciesLogger");

        return services.Configure<UrlsConfig>(configuration.GetSection("urls"))
            .AddHttpClient<ClientsClient>()
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services
            .AddHttpClient<InventoryClient>()
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services
            .AddHttpClient<ProductsClient>()
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services
            .AddHttpClient<SalesClient>()
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services;
    }
}