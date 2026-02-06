using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Application.UseCases.Queries;

/// <summary>
/// Represents the use case for retrieving inventory information for a specific product.
/// </summary>
public class GetInventoriesUseCase() : UseCase<Result<List<Inventory>>>()
{
}
