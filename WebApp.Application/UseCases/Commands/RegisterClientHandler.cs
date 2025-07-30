using Dsr.Architecture.Domain.Entities;
using MediatR;

using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Infrastructure;

namespace WebApp.Application.UseCases.Commands;

/// <summary>
/// Handles the registration of a new client.
/// </summary>
public class RegisterClientHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<RegisterClientUseCase, ResultSimple>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    /// <summary>
    /// Handles the incoming request to register a new client.
    /// </summary>
    /// <param name="request">The request containing client registration details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="ResultSimple"/> indicating the outcome of the operation.</returns>
    public async Task<ResultSimple> Handle(RegisterClientUseCase request, CancellationToken cancellationToken)
    {
        if (request?.Request is null)
            return new ResultSimple(1, "Invalid request");

        var result = await _unitOfWork.ClientRepository.AddAsync(request.Request, cancellationToken);
        if (result != null && string.IsNullOrWhiteSpace(result.ErrorMessage) && result.ResultCode == 0)
            await _unitOfWork.CompleteAsync(cancellationToken);

        return new ResultSimple();
    }
}
