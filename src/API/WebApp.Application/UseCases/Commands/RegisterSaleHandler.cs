using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using MediatR;

using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Domain.Entities;
using WebApp.Domain.Interfaces.Infrastructure;

namespace WebApp.Application.UseCases.Commands;

/// <summary>
/// Handles the registration of a new sale.
/// </summary>
public class RegisterSaleHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<RegisterSaleUseCase, ResultSimple>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    /// <summary>
    /// Handles the incoming request to register a new sale.
    /// </summary>
    /// <param name="request">The request containing sale registration details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="ResultSimple"/> indicating the outcome of the operation.</returns>
    public async Task<ResultSimple> Handle(RegisterSaleUseCase request, CancellationToken cancellationToken)
    {
        if (request?.Request is null)
            return new ResultSimple(1, "Invalid request");

        var sale = request.Request;
        (bool ExistStock, ResultSimple ResultSimple, List<Inventory> inventories) validate =
            await ValidateStockSql(sale, cancellationToken);
        if (validate.ExistStock)
            await AddSaleSql(sale, validate.inventories, cancellationToken);
        else
            return validate.ResultSimple;

        return new ResultSimple();
    }

    /// <summary>
    /// Validates the stock for the sale items.
    /// </summary>
    /// <param name="sale"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<(bool ExistStock, ResultSimple ResultSimple, List<Inventory> inventories)> ValidateStockSql(
        Sale sale, CancellationToken cancellationToken)
    {
        var list = new List<Inventory>();
        var validate = true;
        var outStockProducts = new List<Guid>();

        foreach (var item in sale.Items)
        {
            var inventory = await _unitOfWork.InventoryRepository.FirstAsync(x => x.ProductId == item.ProductId, cancellationToken);
            if ((inventory?.Content?.StockQuantity ?? 0) < item.Quantity)
            {
                validate = false;
                outStockProducts.Add(item.ProductId);
            }
            var inventoryContent = inventory?.Content;
            if (inventoryContent is not null)
                list.Add((Inventory)inventoryContent);
        }
        if (!validate)
        {
            var products = new List<Product>();
            foreach (var productId in outStockProducts)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId, cancellationToken);
                if (product?.Content is not null)
                    products.Add((Product)product.Content);
            }
            var productList = string.Join(", ", products.Select(p => p.Name));
            return (false, new ResultSimple(1, $"Insufficient stock for this products: {productList}"), list);
        }
        return (validate, new ResultSimple(), list);
    }

    /// <summary>
    /// Adds a sale to the database, its associated items if the sale is valid and update inventories stocks.
    /// </summary>
    /// <param name="sale"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task AddSaleSql(Sale sale, List<Inventory> inventories, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SaleRepository.AddAsync(sale, cancellationToken);
        if (result is not null && !string.IsNullOrWhiteSpace(result.ErrorMessage))
        {
            var list = sale!.Items;
            list?.Each(x => x.SaleId = sale.Id);
            // If there are items to add, add them to the sale item repository
            if (list is not null && list.Count != 0)
            {
                var resultItems = await _unitOfWork.SaleItemRepository.AddRangeAsync([.. list], cancellationToken);

                if (resultItems is not null && !string.IsNullOrWhiteSpace(resultItems.ErrorMessage))
                {
                    await inventories.EachAsync(async (inventory, cancelToken) =>
                    {
                        inventory.StockQuantity -= list.First(x => x.ProductId == inventory.ProductId).Quantity;
                        await _unitOfWork.InventoryRepository.UpdateAsync(inventory, cancellationToken);
                    }, cancellationToken);

                    await _unitOfWork.CompleteAsync(cancellationToken);
                }
            }
        }
    }
}