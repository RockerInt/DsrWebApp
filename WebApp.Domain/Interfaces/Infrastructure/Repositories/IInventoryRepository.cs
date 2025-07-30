using Dsr.Architecture.Infrastructure.Persistence.Interfaces;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Infrastructure.Repositories;

/// <summary>
/// Represents a repository for managing inventory data.
/// </summary>
public interface IInventoryRepository: IRepository<Guid, Inventory>
{
}


