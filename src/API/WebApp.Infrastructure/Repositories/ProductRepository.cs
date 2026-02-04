using Dsr.Architecture.Infrastructure.Persistence.EntityFramework;
using Microsoft.Extensions.Logging;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Infrastructure.Repositories;

/// <summary>
/// Implements the <see cref="IProductRepository"/> interface for managing product data in SqlLite.
/// </summary>
public class ProductRepository(AppDbContext dbContext, ILogger<ProductRepository> logger)
    : EntityFrameworkRepository<Guid, Product>(dbContext, logger), IProductRepository
{
}