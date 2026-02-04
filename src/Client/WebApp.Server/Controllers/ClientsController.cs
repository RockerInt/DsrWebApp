using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities.TryCatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApp.Domain.Entities;
using WebApp.Server.Services;

namespace WebApp.Server.Controllers;

/// <summary>
/// API controller for managing clients-related operations.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ClientsController(ClientsClient client, ILogger<ClientsClient> logger) : ControllerBase
{
    // Client instance to interact with the Clients API
    private readonly ClientsClient _client = client;

    // Logger instance for logging information and errors
    private readonly ILogger<ClientsClient> _logger = logger;

    /// <summary>
    /// Retrieves a list of all clients.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Get")]
    [ProducesResponseType(typeof(Result<List<Client>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult?> Get() =>
        await this.Try<IActionResult>(
            async () => Ok(await _client.Get())
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
                StatusCode((int)HttpStatusCode.Created, await _client.Register(request))
                : BadRequest()
            ).Catch(HttpErrorHandler).Apply();

    private async Task<IActionResult?> HttpErrorHandler(Exception e)
    {
        _logger.LogError(e, "An error has occurred while processing the request.");
        return await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError, $"An error has occurred, contact the administrator! {e}"));
    }

}
