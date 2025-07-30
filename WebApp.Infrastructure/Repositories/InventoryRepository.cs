using Dsr.Architecture.Infrastructure.Persistence.EntityFramework;
using Microsoft.Extensions.Logging;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Infrastructure.Repositories;

/// <summary>
/// Implements the <see cref="IInventoryRepository"/> interface for managing inventory data in SqlLite.
/// </summary>
public class InventoryRepository(AppDbContext dbContext, ILogger<InventoryRepository> logger)
    : EntityFrameworkRepository<Guid, Inventory>(dbContext, logger), IInventoryRepository
{
}


