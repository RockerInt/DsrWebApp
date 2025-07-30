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
/// API controller for managing products-related operations.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Retrieves a list of all products.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get")]
    [ProducesResponseType(typeof(Result<List<Product>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult?> Get() =>
        await this.Try<IActionResult>(
            async () => Ok(await _mediator.Send(new GetProductsUseCase()))
        ).Catch(HttpErrorHandler).Apply();

    /// <summary>
    /// Registers a new product.
    /// </summary>
    /// <param name="request">The request containing the product details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the registration.</returns>
    [HttpPost]
    [Route("Register")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult?> Register([FromBody] string name, string description, decimal price, int stock)
        => await this.Try<IActionResult>(
                async () => ModelState.IsValid ?
                StatusCode((int)HttpStatusCode.Created, await _mediator.Send(
                    new RegisterProductUseCase(name, description, price, stock)
                ))
                : BadRequest()
            ).Catch(HttpErrorHandler).Apply();

    private async Task<IActionResult?> HttpErrorHandler(Exception e) => await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError, $"An error has occurred, contact the administrator! {e}"));

}
