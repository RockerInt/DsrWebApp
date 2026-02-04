using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using WebApp.Domain.Enums;

namespace WebApp.Domain.Interfaces.Application.UseCases.Commands;

/// <summary>
/// Represents the use case for updating a inventory stock for a product.
/// </summary>
public class UpdateInventoryStockUseCase(Guid productId, int stock) : UseCase<ResultSimple>()
{
    /// <summary>
    /// Gets or sets the id of the product.
    /// </summary>
    public Guid ProductId { get; set; } = productId;

    /// <summary>
    /// Gets or sets the stock quantity of the product.
    /// </summary>
    public int Stock { get; set; } = stock;
}
