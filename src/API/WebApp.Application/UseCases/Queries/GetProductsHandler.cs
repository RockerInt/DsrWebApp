using Dsr.Architecture.Domain.Entities;
using MediatR;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Queries;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Application.UseCases.Queries;

/// <summary>
/// Handles the retrieval of products data.
/// </summary>
public class GetProductsHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductsUseCase, Result<List<Product>>>
{
    private readonly IProductRepository _productRepository = productRepository;

    /// <summary>
    /// Handles the incoming request to get all products.
    /// </summary>
    /// <param name="request">The request to get products.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing a list of products or an error message.</returns>
    public async Task<Result<List<Product>>> Handle(GetProductsUseCase request, CancellationToken cancellationToken)
    {
        List<Product> products = [];

        var result = await _productRepository.GetAllAsync(cancellationToken);
        if (result != null && result.Content != null)
            products = [.. result.Content];

        if (products is not null && products.Count > 0)
            return new Result<List<Product>>(products);
        else
            return new Result<List<Product>>([], 1, "No products found.");

    }
}