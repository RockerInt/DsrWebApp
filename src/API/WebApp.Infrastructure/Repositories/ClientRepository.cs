using Dsr.Architecture.Infrastructure.Persistence.EntityFramework;
using Microsoft.Extensions.Logging;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Infrastructure.Repositories;

/// <summary>
/// Implements the <see cref="IClientRepository"/> interface for managing client data in SqlLite.
/// </summary>
public class ClientRepository(AppDbContext dbContext, ILogger<ClientRepository> logger)
    : EntityFrameworkRepository<Guid, Client>(dbContext, logger), IClientRepository
{
}

