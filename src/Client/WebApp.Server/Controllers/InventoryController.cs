using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities.TryCatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApp.Domain.Entities;
using WebApp.Server.Services;

namespace WebApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController(InventoryClient client, ILogger<InventoryClient> logger) : ControllerBase
{
    // Client instance to interact with the Inventory API
    private readonly InventoryClient _client = client;
    
    // Logger instance for logging information and errors
    private readonly ILogger<InventoryClient> _logger = logger;

    /// <summary>
    /// Retrieves a list of all inventories.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get")]
    [ProducesResponseType(typeof(Result<List<Inventory>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult?> Get() =>
        await this.Try<IActionResult>(
            async () => Ok(await _client.Get())
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
            async () => Ok(await _client.Get(productId))
        ).Catch(HttpErrorHandler).Apply();

    [HttpPut("stock")]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult?> UpdateInventoryStock([FromBody] Guid productId, int stock)
        => await this.Try<IActionResult>(
                async () => ModelState.IsValid ?
                StatusCode((int)HttpStatusCode.Created, await _client.Stock(productId, stock))
                : BadRequest()
            ).Catch(HttpErrorHandler).Apply();

    private async Task<IActionResult?> HttpErrorHandler(Exception e) 
    {
        _logger.LogError(e, "An error has occurred while processing the request.");
        return await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError, $"An error has occurred, contact the administrator! {e}"));
    }
}

