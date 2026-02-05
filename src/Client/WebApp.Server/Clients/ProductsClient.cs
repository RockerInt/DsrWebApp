using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Domain.Entities;
using WebApp.Server.Config;

namespace WebApp.Server.Services;

/// <summary>
/// Client to interact with Products API endpoints
/// </summary>
/// <param name="httpClient"></param>
/// <param name="urls"></param>
public class ProductsClient(HttpClient httpClient, IOptions<UrlsConfig> urls) 
    : Dsr.Architecture.Infrastructure.Provider.Client(httpClient, urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of products from the Products API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<Product>>> Get()
    {
        var response = await Get<Result<List<Product>>>(UrlsConfig.ProductsServices.Get());

        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new([]);
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }
    
    /// <summary>
    /// Registers a new product via the Products API
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResultSimple> Register(string name, string description, decimal price, int stock)
    {
        var response = await Post<ResultSimple>(UrlsConfig.ProductsServices.Register(), JsonConvert.SerializeObject(new { Name = name, Description = description, Price = price, Stock = stock }));
        
        if ((response?.ResultCode ?? -1) == 0)
            return response!.Content ?? new();
        else
            throw new Exception($"Exception: {Environment.NewLine} ResultCode: {Convert.ToInt16(response?.ResultCode)}, {Environment.NewLine} Messege: {response?.ErrorMessage}");
    }

}