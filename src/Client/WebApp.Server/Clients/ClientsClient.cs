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
public class ClientsClient(HttpClient httpClient, IOptions<UrlsConfig> urls)
    : Dsr.Architecture.Infrastructure.Provider.Client(httpClient, urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of clients from the Clients API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<Client>>> Get()
    {
        var response = await Get<Result<List<Client>>>(UrlsConfig.ClientsServices.Get());

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new([]);
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }

    /// <summary>
    /// Registers a new client via the Clients API
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResultSimple> Register(Client client)
    {
        var response = await Post<Client, ResultSimple>(UrlsConfig.ClientsServices.Register(), client);

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new();
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }

}