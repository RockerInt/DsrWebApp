using Dsr.Architecture.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;
using WebApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Interfaces.Infrastructure;

namespace WebApp.Infrastructure;

/// <summary>
/// Provides extension methods for dependency injection in the Infrastructure layer.
/// </summary>
public static class DependecyInjection
{
    /// <summary>
    /// Adds infrastructure-specific services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> for retrieving settings.</param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceServices(configuration);
        var persistenceSettings = services.BuildServiceProvider().GetRequiredService<IPersistenceSettings>();

        /*"ConnectionString": "mongodb://admin:password@localhost:27017/WebAppDb?authSource=admin", if mongo*/

        return services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(persistenceSettings.ConnectionString)
            )
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IInventoryRepository, InventoryRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IClientRepository, ClientRepository>()
            .AddScoped<ISaleItemRepository, SaleItemRepository>()
            .AddScoped<ISaleRepository, SaleRepository>();
    }
}