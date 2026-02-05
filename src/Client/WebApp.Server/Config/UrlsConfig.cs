namespace WebApp.Server.Config;

/// <summary>
/// Configuration class for service URLs.
/// </summary>
public class UrlsConfig
{
    /// <summary>
    /// The base URL of the API service.
    /// </summary>
    public required string ApiService { get; set; }

    /// <summary>
    /// The base URL of the clients service.
    /// </summary>
    public class ClientsServices
    {
        public static string Get() => $"/Clients/Get";

        public static string GetById(int id) => $"/Clients/Get/{id}"; //TODO: Implement GetById in ClientsController

        public static string Register() => $"/Clients/Register";
    }

    /// <summary>
    /// The base URL of the inventory service.
    /// </summary>
    public class InventoryServices
    {
        public static string Get() => $"/Inventory/Get";

        public static string GetByProductId(Guid id) => $"/Inventory/Get/{id}"; 

        public static string Stock() => $"/Inventory/Stock";
    }

    /// <summary>
    /// The base URL of the products service.
    /// </summary>
    public class ProductsServices
    {
        public static string Get() => $"/Products/Get";

        public static string GetById(int id) => $"/Products/Get/{id}"; //TODO: Implement GetById in ProductsController

        public static string Register() => $"/Products/Register";
    }

    /// <summary>
    /// The base URL of the sales service.
    /// </summary>
    public class SalesServices
    {
        public static string Get() => $"/Sales/Get";

        public static string GetById(int id) => $"/Sales/Get/{id}"; //TODO: Implement GetById in SalesController

        public static string Register() => $"/Sales/Register";
    }
}

