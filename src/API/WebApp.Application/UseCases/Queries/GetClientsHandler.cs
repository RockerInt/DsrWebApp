using Dsr.Architecture.Domain.Entities;
using MediatR;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Queries;
using WebApp.Domain.Interfaces.Infrastructure.Repositories;

namespace WebApp.Application.UseCases.Queries;

/// <summary>
/// Handles the retrieval of clients data.
/// </summary>
public class GetClientsHandler(IClientRepository clientRepository)
    : IRequestHandler<GetClientsUseCase, Result<List<Client>>>
{
    private readonly IClientRepository _clientRepository = clientRepository;

    /// <summary>
    /// Handles the incoming request to get all clients.
    /// </summary>
    /// <param name="request">The request to get clients.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing a list of clients or an error message.</returns>
    public async Task<Result<List<Client>>> Handle(GetClientsUseCase request, CancellationToken cancellationToken)
    {
        List<Client> clients = [];

        var result = await _clientRepository.GetAllAsync(cancellationToken);
            if (result != null && result.Content != null)
                clients = [.. result.Content];        

        if (clients is not null && clients.Count > 0)
            return new Result<List<Client>>(clients);
        else
            return new Result<List<Client>>([], 1, "No clients found.");

    }
}