using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Domain.Entities;
using WebApp.Server.Config;

namespace WebApp.Server.Services;

/// <summary>
/// Client to interact with Sales API endpoints
/// </summary>
/// <param name="httpClient"></param>
/// <param name="urls"></param>
public class SalesClient(HttpClient httpClient, IOptions<UrlsConfig> urls) 
    : Dsr.Architecture.Infrastructure.Provider.Client(httpClient, urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of sales from the Sales API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<Sale>>> Get()
    {
        var response = await Get<Result<List<Sale>>>(UrlsConfig.SalesServices.Get());

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new([]);
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }
    
    /// <summary>
    /// Registers a new sale via the Sales API
    /// </summary>
    /// <param name="sale"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResultSimple> Register(Sale sale)
    {
        var response = await Post<Sale, ResultSimple>(UrlsConfig.SalesServices.Register(), sale);

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new();
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }

}