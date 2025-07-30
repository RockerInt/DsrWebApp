using Dsr.Architecture.Infrastructure.Persistence;
using Dsr.Architecture.Utilities.TryCatch;
using Microsoft.Extensions.Logging;
using WebApp.Domain.Interfaces.Infrastructure;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Infrastructure;

/// <summary>
/// Unit of Work implementation for managing multiple repositories in SqlLite.
/// This class encapsulates the repositories for client, product, inventory, sale, and sale item data.
/// </summary>
/// <param name="dbContext"></param>
/// <param name="clientRepository"></param>
/// <param name="productRepository"></param>
/// <param name="inventoryRepository"></param>
/// <param name="saleRepository"></param>
/// <param name="saleItemRepository"></param>
/// <param name="logger"></param>
public class UnitOfWork(
    AppDbContext dbContext,
    IClientRepository clientRepository,
    IProductRepository productRepository,
    IInventoryRepository inventoryRepository,
    ISaleRepository saleRepository,
    ISaleItemRepository saleItemRepository,
    ILogger<UnitOfWork> logger) : UnitOfWorkBase(dbContext), IUnitOfWork
{

    private readonly ILogger<UnitOfWork> _logger = logger;
    public IClientRepository ClientRepository { get; } = clientRepository;
    public IProductRepository ProductRepository { get; } = productRepository;
    public IInventoryRepository InventoryRepository { get; } = inventoryRepository;
    public ISaleRepository SaleRepository { get; } = saleRepository;
    public ISaleItemRepository SaleItemRepository { get; } = saleItemRepository;

    /// <summary>
    /// Completes the unit of work by saving changes to the database.
    /// This method is wrapped in a try-catch block to handle any exceptions that may occur
    /// during the save operation. If an error occurs, it logs the error and rethrows it for further handling.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public new Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        => this.Try(async () => await base.CompleteAsync(cancellationToken))
        .Catch((error) =>
        {
            _logger.LogError(error, "An error occurred while completing the unit of work.");
            throw error;
        })
        .Apply();
}