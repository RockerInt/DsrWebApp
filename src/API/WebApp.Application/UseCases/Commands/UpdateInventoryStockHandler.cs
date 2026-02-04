using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using MediatR;

using System.Collections.Generic;
using System.Threading;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Domain.Entities;
using WebApp.Domain.Interfaces.Infrastructure;

namespace WebApp.Application.UseCases.Commands;

/// <summary>
/// Handles the updating of a inventory stock.
/// </summary>
public class UpdateInventoryStockHandle(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateInventoryStockUseCase, ResultSimple>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    /// <summary>
    /// Handles the incoming request to update a inventory stock.
    /// </summary>
    /// <param name="request">The request containing sale registration details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="ResultSimple"/> indicating the outcome of the operation.</returns>
    public async Task<ResultSimple> Handle(UpdateInventoryStockUseCase request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new ResultSimple(1, "Invalid request");

        var productId = request.ProductId;
        var inventory = await _unitOfWork.InventoryRepository.FirstAsync(x => x.ProductId == productId, cancellationToken);
        if (inventory?.Content is not null)
        {
            inventory.Content.StockQuantity = request.Stock;
            var result = await _unitOfWork.InventoryRepository.UpdateAsync(inventory.Content, cancellationToken);

            if (result is not null && string.IsNullOrWhiteSpace(result.ErrorMessage) && result.ResultCode == 0)
                await _unitOfWork.CompleteAsync(cancellationToken);
        }

        return new ResultSimple();
    }
}