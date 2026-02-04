using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities.TryCatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Application.UseCases.Commands;
using WebApp.Domain.Interfaces.Application.UseCases.Requests;

namespace WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Retrieves a list of all inventories.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get")]
    [ProducesResponseType(typeof(Result<List<Inventory>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult?> Get() =>
        await this.Try<IActionResult>(
            async () => Ok(await _mediator.Send(new GetInventoriesUseCase()))
        ).Catch(HttpErrorHandler).Apply();

    

    /// <summary>
    /// Retrieves a inventory by product id.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get/{productId:guid}")]
    [ProducesResponseType(typeof(Result<List<Inventory>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult?> Get(Guid productId) =>
        await this.Try<IActionResult>(
            async () => Ok(await _mediator.Send(new GetInventoryUseCase(productId)))
        ).Catch(HttpErrorHandler).Apply();

    [HttpPut("stock")]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult?> UpdateInventoryStock([FromBody] Guid productId, int stock)
        => await this.Try<IActionResult>(
                async () => ModelState.IsValid ?
                StatusCode((int)HttpStatusCode.Created, await _mediator.Send(new UpdateInventoryStockUseCase(productId, stock)))
                : BadRequest()
            ).Catch(HttpErrorHandler).Apply();

    private async Task<IActionResult?> HttpErrorHandler(Exception e) => await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError, $"An error has occurred, contact the administrator! {e}"));

}

