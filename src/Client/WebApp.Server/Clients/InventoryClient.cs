using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Domain.Entities;
using WebApp.Server.Config;

namespace WebApp.Server.Services;

/// <summary>
/// Client to interact with Inventory API endpoints
/// </summary>
/// <param name="urls"></param>
public class InventoryClient(IOptions<UrlsConfig> urls) : Dsr.Architecture.Infrastructure.Provider.Client(urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of inventory items from the Inventory API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Inventory>> Get()
    {
        var response = await Get<HttpResponseMessage>(UrlsConfig.InventoryServices.Get());

        if (response?.Content?.IsSuccessStatusCode ?? false)
        {
            return WebUtilities.ValidateContent(response.Content).ToEntityListSimple<Inventory>();
        }
        else
        {
            throw new Exception($"HttpException: {Environment.NewLine} StatusCode: {Convert.ToInt16(response?.Content?.StatusCode ?? System.Net.HttpStatusCode.InternalServerError)}, {Environment.NewLine} Messege: {WebUtilities.ValidateContent(response.Content)}");
        }
    }

    public async Task<List<Inventory>> Get(Guid productId)
    {
        var response = await Get<HttpResponseMessage>(UrlsConfig.InventoryServices.GetByProductId(productId));

        if (response?.Content?.IsSuccessStatusCode ?? false)
        {
            return WebUtilities.ValidateContent(response.Content).ToEntityListSimple<Inventory>();
        }
        else
        {
            throw new Exception($"HttpException: {Environment.NewLine} StatusCode: {Convert.ToInt16(response?.Content?.StatusCode ?? System.Net.HttpStatusCode.InternalServerError)}, {Environment.NewLine} Messege: {WebUtilities.ValidateContent(response.Content)}");
        }
    }
    
    /// <summary>
    /// Updates stock for a specific product via the Inventory API
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="stock"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResultSimple> Stock(Guid productId, int stock)
    {
        var response = await Post<HttpResponseMessage>(UrlsConfig.InventoryServices.Stock(), JsonConvert.SerializeObject(new { ProductId = productId, Stock = stock }));

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