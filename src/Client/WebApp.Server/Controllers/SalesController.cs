using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities.TryCatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApp.Domain.Entities;
using WebApp.Server.Services;

namespace WebApp.Server.Controllers;

/// <summary>
/// API controller for managing sales-related operations.
/// </summary>
[ApiController]
[Route("[controller]")]
public class SalesController(SalesClient client, ILogger<SalesClient> logger) : ControllerBase
{
    // Client instance to interact with the Sales API
    private readonly SalesClient _client = client;

    // Logger instance for logging information and errors
    private readonly ILogger<SalesClient> _logger = logger;

    /// <summary>
    /// Retrieves a list of all sales.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult?> Get() =>
        await this.Try<IActionResult>(
            async () => Ok(await _client.Get())
        ).Catch(HttpErrorHandler).Apply();

    /// <summary>
    /// Registers a new sale.
    /// </summary>
    /// <param name="request">The request containing the sale details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the registration.</returns>
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult?> Register([FromBody] Sale request)
        => await this.Try<IActionResult>(
                async () => ModelState.IsValid ?
                StatusCode((int)HttpStatusCode.Created, await _client.Register(request))
                : BadRequest()
            ).Catch(HttpErrorHandler).Apply();

    private async Task<IActionResult?> HttpErrorHandler(Exception e)
    {
        _logger.LogError(e, "An error has occurred while processing the request.");
        return await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError, $"An error has occurred, contact the administrator! {e}"));
    }
}
