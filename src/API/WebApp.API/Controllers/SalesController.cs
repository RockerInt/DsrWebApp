using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities.TryCatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Application.UseCases.Requests;

namespace WebApp.API.Controllers;

/// <summary>
/// API controller for managing sales-related operations.
/// </summary>
[ApiController]
[Route("[controller]")]
public class SalesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Retrieves a list of all sales.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get")]
    [ProducesResponseType(typeof(Result<List<Sale>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult?> Get() =>
        await this.Try<IActionResult>(
            async () => Ok(await _mediator.Send(new GetSalesUseCase()))
        ).Catch(HttpErrorHandler).Apply();

    /// <summary>
    /// Registers a new sale.
    /// </summary>
    /// <param name="request">The request containing the sale details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the registration.</returns>
    [HttpPost]
    [Route("Register")]
    [Route("Get")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult?> Register([FromBody] Sale request)
        => await this.Try<IActionResult>(
                async () => ModelState.IsValid ?
                StatusCode((int)HttpStatusCode.Created, await _mediator.Send(new RegisterSaleUseCase(request)))
                : BadRequest()
            ).Catch(HttpErrorHandler).Apply();

    private async Task<IActionResult?> HttpErrorHandler(Exception e) => await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError, $"An error has occurred, contact the administrator! {e}"));

}
