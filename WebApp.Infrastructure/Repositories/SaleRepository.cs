using Dsr.Architecture.Infrastructure.Persistence.EntityFramework;
using Microsoft.Extensions.Logging;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Infrastructure.Repositories;

/// <summary>
/// Implements the <see cref="ISaleRepository"/> interface for managing sales data in SqlLite.
/// </summary>
public class SaleRepository(AppDbContext dbContext, ILogger<SaleRepository> logger)
     : EntityFrameworkRepository<Guid, Sale>(dbContext, logger), ISaleRepository
{
}
