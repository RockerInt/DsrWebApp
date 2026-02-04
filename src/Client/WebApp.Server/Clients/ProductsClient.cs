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
/// <param name="urls"></param>
public class ProductsClient(IOptions<UrlsConfig> urls) : Dsr.Architecture.Infrastructure.Provider.Client(urls.Value.ApiService)
{
    /// <summary>
    /// Gets a list of products from the Products API
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Product>> Get()
    {
        var response = await Get<HttpResponseMessage>(UrlsConfig.ProductsServices.Get());

        if (response?.Content?.IsSuccessStatusCode ?? false)
        {
            return WebUtilities.ValidateContent(response.Content).ToEntityListSimple<Product>();
        }
        else
        {
            throw new Exception($"HttpException: {Environment.NewLine} StatusCode: {Convert.ToInt16(response?.Content?.StatusCode ?? System.Net.HttpStatusCode.InternalServerError)}, {Environment.NewLine} Messege: {WebUtilities.ValidateContent(response.Content)}");
        }
    }
    
    /// <summary>
    /// Registers a new product via the Products API
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResultSimple> Register(string name, string description, decimal price, int stock)
    {
        var response = await Post<HttpResponseMessage>(UrlsConfig.ProductsServices.Register(), JsonConvert.SerializeObject(new { Name = name, Description = description, Price = price, Stock = stock }));
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