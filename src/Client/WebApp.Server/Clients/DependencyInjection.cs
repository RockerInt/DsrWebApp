using WebApp.Server.Config;
using WebApp.Server.Services;
using WebApp.Server.Resilience;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        
        var urlsConfig = configuration.GetSection("urls").Get<UrlsConfig>() ?? new UrlsConfig() { ApiService = "http://api:8080/" };

        return services.Configure<UrlsConfig>(configuration.GetSection("urls"))
            .AddHttpClient<ClientsClient>(client => { client.BaseAddress = new Uri(urlsConfig.ApiService); })
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services
            .AddHttpClient<InventoryClient>(client => { client.BaseAddress = new Uri(urlsConfig.ApiService); })
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services
            .AddHttpClient<ProductsClient>(client => { client.BaseAddress = new Uri(urlsConfig.ApiService); })
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services
            .AddHttpClient<SalesClient>(client => { client.BaseAddress = new Uri(urlsConfig.ApiService); })
            .AddPolicyHandler(HttpPolicies.GetResiliencePolicy(logger))
            .Services;
    }
}