using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Domain.Interfaces.Infrastructure;

/// <summary>
/// Represents a repository for managing client data.
/// </summary>
public interface IUnitOfWork : Dsr.Architecture.Infrastructure.Persistence.Interfaces.IUnitOfWork
{
    IClientRepository ClientRepository { get; }
    IProductRepository ProductRepository { get; }
    IInventoryRepository InventoryRepository { get; }
    ISaleRepository SaleRepository { get; }
    ISaleItemRepository SaleItemRepository { get; }
}

