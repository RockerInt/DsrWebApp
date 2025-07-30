using Dsr.Architecture.Infrastructure.Persistence.Interfaces;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Infrastructure.Repositories;

/// <summary>
/// Represents a repository for managing sales data.
/// </summary>
public interface ISaleRepository : IRepository<Guid, Sale>
{
}
