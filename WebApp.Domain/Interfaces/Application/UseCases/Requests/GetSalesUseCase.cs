using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Application.UseCases.Requests;

/// <summary>
/// Represents the use case for retrieving a list of sales.
/// </summary>
public class GetSalesUseCase() : UseCase<Result<List<Sale>>>()
{
}
