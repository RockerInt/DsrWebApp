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
public class InventoryClient(HttpClient httpClient, IOptions<UrlsConfig> urls) 
:    Dsr.Architecture.Infrastructure.Provider.Client(httpClient, urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of inventory items from the Inventory API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<Inventory>>> Get()
    {
        var response = await Get<Result<List<Inventory>>>(UrlsConfig.InventoryServices.Get());

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new([]);
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }

    public async Task<Result<List<Inventory>>> Get(Guid productId)
    {
        var response = await Get<Result<List<Inventory>>>(UrlsConfig.InventoryServices.GetByProductId(productId));

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new([]);
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
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
        var response = await Post<ResultSimple>(UrlsConfig.InventoryServices.Stock(), JsonConvert.SerializeObject(new { ProductId = productId, Stock = stock }));

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new();
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }

}