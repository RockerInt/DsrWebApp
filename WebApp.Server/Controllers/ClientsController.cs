using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities.TryCatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Application.UseCases.Requests;

namespace WebApp.Server.Controllers;

/// <summary>
/// API controller for managing clients-related operations.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ClientsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Retrieves a list of all clients.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get")]
    [ProducesResponseType(typeof(Result<List<Client>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult?> Get() =>
        await this.Try<IActionResult>(
            async () => Ok(await _mediator.Send(new GetClientsUseCase()))
        ).Catch(HttpErrorHandler).Apply();

    /// <summary>
    /// Registers a new client.
    /// </summary>
    /// <param name="request">The request containing the client details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the registration.</returns>
    [HttpPost]
    [Route("Register")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult?> Register([FromBody] Client request)
        => await this.Try<IActionResult>(
                async () => ModelState.IsValid ?
                StatusCode((int)HttpStatusCode.Created, await _mediator.Send(new RegisterClientUseCase(request)))
                : BadRequest()
            ).Catch(HttpErrorHandler).Apply();

    private async Task<IActionResult?> HttpErrorHandler(Exception e) => await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError, $"An error has occurred, contact the administrator! {e}"));

}
