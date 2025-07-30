using Dsr.Architecture.Domain.Entities;
using MediatR;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Requests;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Application.UseCases.Requests;

/// <summary>
/// Handles the retrieval of sales data.
/// </summary>
public class GetSalesHandler(ISaleRepository saleRepository, ISaleItemRepository saleItemRepository)
    : IRequestHandler<GetSalesUseCase, Result<List<Sale>>>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly ISaleItemRepository _saleItemRepository = saleItemRepository;

    /// <summary>
    /// Handles the incoming request to get all sales.
    /// </summary>
    /// <param name="request">The request to get sales.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing a list of sales or an error message.</returns>
    public async Task<Result<List<Sale>>> Handle(GetSalesUseCase request, CancellationToken cancellationToken)
    {
        List<Sale> sales = [];

        var result = await _saleRepository.GetAllAsync(cancellationToken);
        if (result != null && result.Content != null && result.Content.Any())
        {
            foreach (var sale in result.Content)
            {
                if (sale is null)
                    continue;
                if (sale.Items is not null && sale.Items.Count > 0)
                    continue;
                var itemsResult = await _saleItemRepository.GetByAsync(x => x.SaleId == sale.Id, cancellationToken);
                if (itemsResult != null && itemsResult.Content != null)
                    sale.Items = [.. itemsResult.Content];
                else
                    sale.Items = [];
            }
            sales = [.. result.Content];
        }

        if (sales is not null && sales.Count > 0)
            return new Result<List<Sale>>(sales);
        else
            return new Result<List<Sale>>([], 1, "No sales found.");

    }
}