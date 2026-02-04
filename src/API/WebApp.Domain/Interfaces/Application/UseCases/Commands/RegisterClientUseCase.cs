using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Domain.Entities;

namespace WebApp.Domain.Interfaces.Application.UseCases.Commands;

/// <summary>
/// Represents the use case for registering a new client.
/// </summary>
public class RegisterClientUseCase(Client? request) : UseCase<Client, ResultSimple>(request)
{
}
