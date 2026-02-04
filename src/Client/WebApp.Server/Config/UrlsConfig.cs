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
        public static string Get() => $"/api/v1/Clients/Get";

        public static string GetById(int id) => $"/api/v1/Clients/Get/{id}"; //TODO: Implement GetById in ClientsController

        public static string Register() => $"/api/v1/Clients/Register";
    }

    /// <summary>
    /// The base URL of the inventory service.
    /// </summary>
    public class InventoryServices
    {
        public static string Get() => $"/api/v1/Inventory/Get";

        public static string GetByProductId(Guid id) => $"/api/v1/Inventory/Get/{id}"; 

        public static string Stock() => $"/api/v1/Inventory/Stock";
    }

    /// <summary>
    /// The base URL of the products service.
    /// </summary>
    public class ProductsServices
    {
        public static string Get() => $"/api/v1/Products/Get";

        public static string GetById(int id) => $"/api/v1/Products/Get/{id}"; //TODO: Implement GetById in ProductsController

        public static string Register() => $"/api/v1/Products/Register";
    }

    /// <summary>
    /// The base URL of the sales service.
    /// </summary>
    public class SalesServices
    {
        public static string Get() => $"/api/v1/Sales/Get";

        public static string GetById(int id) => $"/api/v1/Sales/Get/{id}"; //TODO: Implement GetById in SalesController

        public static string Register() => $"/api/v1/Sales/Register";
    }
}

