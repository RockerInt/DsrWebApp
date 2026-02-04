using Dsr.Architecture.Infrastructure.Persistence.Interfaces;
using WebApp.Domain.Entities; 

namespace WebApp.Domain.Interfaces.Infrastructure.Repositories;

/// <summary>
/// Represents a repository for managing product data.
/// </summary> 
public interface IProductRepository : IRepository<Guid, Product>
{
}