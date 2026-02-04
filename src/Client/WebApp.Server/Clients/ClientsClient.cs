using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Domain.Entities;
using WebApp.Server.Config;

namespace WebApp.Server.Services;

/// <summary>
/// Client to interact with Clients API endpoints
/// </summary>
/// <param name="urls"></param>
public class ClientsClient(IOptions<UrlsConfig> urls) : Dsr.Architecture.Infrastructure.Provider.Client(urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of clients from the Clients API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Client>> Get()
    {
        var response = await Get<HttpResponseMessage>(UrlsConfig.ClientsServices.Get());

        if (response?.Content?.IsSuccessStatusCode ?? false)
        {
            return WebUtilities.ValidateContent(response.Content).ToEntityListSimple<Client>();
        }
        else
        {
            throw new Exception($"HttpException: {Environment.NewLine} StatusCode: {Convert.ToInt16(response?.Content?.StatusCode ?? System.Net.HttpStatusCode.InternalServerError)}, {Environment.NewLine} Messege: {WebUtilities.ValidateContent(response.Content)}");
        }
    }
    
    /// <summary>
    /// Registers a new client via the Clients API
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResultSimple> Register(Client client)
    {
        var response = await Post<HttpResponseMessage>(UrlsConfig.ClientsServices.Register(), JsonConvert.SerializeObject(client));

        if (response?.Content?.IsSuccessStatusCode ?? false)
        {
            return WebUtilities.ValidateContent(response.Content).ToEntitySimple<ResultSimple>();
        }
        else
        {
            throw new Exception($"HttpException: {Environment.NewLine} StatusCode: {Convert.ToInt16(response?.Content?.StatusCode ?? System.Net.HttpStatusCode.InternalServerError)}, {Environment.NewLine} Messege: {WebUtilities.ValidateContent(response.Content)}");
        }
    }

}