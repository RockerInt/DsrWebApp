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
/// <param name="urls"></param>
public class SalesClient(IOptions<UrlsConfig> urls) : Dsr.Architecture.Infrastructure.Provider.Client(urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of sales from the Sales API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Sale>> Get()
    {
        var response = await Get<HttpResponseMessage>(UrlsConfig.SalesServices.Get());

        if (response?.Content?.IsSuccessStatusCode ?? false)
        {
            return WebUtilities.ValidateContent(response.Content).ToEntityListSimple<Sale>();
        }
        else
        {
            throw new Exception($"HttpException: {Environment.NewLine} StatusCode: {Convert.ToInt16(response?.Content?.StatusCode ?? System.Net.HttpStatusCode.InternalServerError)}, {Environment.NewLine} Messege: {WebUtilities.ValidateContent(response.Content)}");
        }
    }
    
    /// <summary>
    /// Registers a new sale via the Sales API
    /// </summary>
    /// <param name="sale"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResultSimple> Register(Sale sale)
    {
        var response = await Post<HttpResponseMessage>(UrlsConfig.SalesServices.Register(), JsonConvert.SerializeObject(sale));

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