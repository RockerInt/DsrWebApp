using Dsr.Architecture.Domain.Entities;
using MediatR;

using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Infrastructure;

namespace WebApp.Application.UseCases.Commands;

/// <summary>
/// Handles the registration of a new product.
/// </summary>
public class RegisterProductHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<RegisterProductUseCase, ResultSimple>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    /// <summary>
    /// Handles the incoming request to register a new product.
    /// </summary>
    /// <param name="request">The request containing product registration details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="ResultSimple"/> indicating the outcome of the operation.</returns>
    public async Task<ResultSimple> Handle(RegisterProductUseCase request, CancellationToken cancellationToken)
    {
        if (request?.Request is null)
            return new ResultSimple(1, "Invalid request");

        var product = new Product(request.Request.Name, request.Request.Description, request.Request.Price);

        var resultProduct = await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken);

        if (resultProduct != null && !string.IsNullOrWhiteSpace(resultProduct.ErrorMessage))
        {
            var resultInventory = await _unitOfWork.InventoryRepository.AddAsync(
                new Inventory(product.Id, request.Request.Stock), cancellationToken
            );

            if (resultInventory != null && string.IsNullOrWhiteSpace(resultInventory.ErrorMessage) && resultProduct.ResultCode == 0)
                await _unitOfWork.CompleteAsync(cancellationToken);
        }

        return new ResultSimple();
    }
}
