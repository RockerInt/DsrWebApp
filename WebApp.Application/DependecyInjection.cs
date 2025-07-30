using Dsr.Architecture.Application;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Domain.Entities;

namespace WebApp.Application;

/// <summary>
/// Provides extension methods for dependency injection in the Application layer.
/// </summary>
public static class DependecyInjection
{
    /// <summary>
    /// Adds application-specific services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddApplicationServices()
                   .AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Client).Assembly))
                   .AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly));
                   // Sql CQRS implementations
                //    .AddScoped<IRequestHandler<RegisterClientUseCase, ResultSimple>, RegisterClientHandler>()
                //    .AddScoped<IRequestHandler<RegisterProductUseCase, ResultSimple>, RegisterProductHandler>()
                //    .AddScoped<IRequestHandler<RegisterSaleUseCase, ResultSimple>, RegisterSaleHandler>()
                //    .AddScoped<IRequestHandler<UpdateInventoryStockUseCase, ResultSimple>, UpdateInventoryStockHandler>()
                //    .AddScoped<IRequestHandler<GetClientsUseCase, Result<List<Client>>>, GetClientsHandler>()
                //    .AddScoped<IRequestHandler<GetProductsUseCase, Result<List<Product>>>, GetProductsHandler>()
                //    .AddScoped<IRequestHandler<GetInventoryUseCase, Result<Inventory>>, GetInventorysHandler>()
                //    .AddScoped<IRequestHandler<GetSalesUseCase, Result<List<Sale>>>, GetSalesHandler>();
}
