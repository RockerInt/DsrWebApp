using Dsr.Architecture.Domain.Entities;
using MediatR;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Queries;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Application.UseCases.Queries;

/// <summary>
/// Handles the retrieval of inventorys data.
/// </summary>
public class GetInventorysHandler(IInventoryRepository inventoryRepository, IProductRepository productRepository)
    : IRequestHandler<GetInventoryUseCase, Result<Inventory>>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    private readonly IProductRepository _productRepository = productRepository;

    /// <summary>
    /// Handles the incoming request to get all inventorys.
    /// </summary>
    /// <param name="request">The request to get inventorys.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing a list of inventorys or an error message.</returns>
    public async Task<Result<Inventory>> Handle(GetInventoryUseCase request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new Result<Inventory>(null, 1, "Invalid request");

        Inventory? inventory = null;

        if ((request?.Request ?? Guid.Empty) != Guid.Empty)
        {
            var result = await _inventoryRepository.FirstAsync(x => x.ProductId == request!.Request, cancellationToken);
            if (result != null && result.Content != null)
            {
                var product = await _productRepository.GetByIdAsync(result.Content.ProductId, cancellationToken);
                result.Content.Product = product.Content;
                inventory = (Inventory)result.Content;
            }            
        }
        
        if (inventory is not null)
            return new Result<Inventory>(inventory);
        else
            return new Result<Inventory>(null, 1, "No inventories found.");

    }
}