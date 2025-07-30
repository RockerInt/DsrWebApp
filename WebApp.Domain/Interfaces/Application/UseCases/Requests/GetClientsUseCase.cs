using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Application.UseCases.Requests;

/// <summary>
/// Represents the use case for a list of clients.
/// </summary>
public class GetClientsUseCase() : UseCase<Result<List<Client>>>()
{
}
