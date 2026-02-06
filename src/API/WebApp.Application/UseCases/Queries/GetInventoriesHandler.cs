using Dsr.Architecture.Domain.Entities;
using MediatR;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Queries;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Application.UseCases.Queries;

/// <summary>
/// Handles the retrieval of inventories data.
/// </summary>
public class GetInventoriesHandler(IInventoryRepository inventoryRepository, IProductRepository productRepository)
    : IRequestHandler<GetInventoriesUseCase, Result<List<Inventory>>>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    private readonly IProductRepository _productRepository = productRepository;

    /// <summary>
    /// Handles the incoming request to get all inventories.
    /// </summary>
    /// <param name="request">The request to get inventories.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing a list of inventories or an error message.</returns>
    public async Task<Result<List<Inventory>>> Handle(GetInventoriesUseCase request, CancellationToken cancellationToken)
    {
        List<Inventory> inventories = [];

        var result = await _inventoryRepository.GetAllAsync(cancellationToken);
        if (result != null && result.Content != null)
            inventories = [.. result.Content];

        if (inventories is not null && inventories.Count > 0)
            return new Result<List<Inventory>>(inventories);
        else
            return new Result<List<Inventory>>(null, 1, "No inventories found.");

    }
}