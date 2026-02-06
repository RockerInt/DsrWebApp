using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Application.UseCases.Queries;

/// <summary>
/// Represents the use case for a list of products.
/// </summary>
public class GetProductsUseCase() : UseCase<Result<List<Product>>>()
{
}

