using Dsr.Architecture.Infrastructure.Persistence.Interfaces;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Infrastructure.Repositories;

/// <summary>
/// Represents a repository for managing sale items data.
/// </summary>
public interface ISaleItemRepository : IRepository<Guid, SaleItem>
{
}
