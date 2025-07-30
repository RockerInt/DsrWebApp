using Dsr.Architecture.Infrastructure.Persistence.Interfaces;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Infrastructure.Repositories;

/// <summary>
/// Represents a repository for managing client data.
/// </summary>
public interface IClientRepository : IRepository<Guid, Client>
{
}

