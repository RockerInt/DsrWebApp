using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using WebApp.Domain.Interfaces.Domain.Entities;

namespace WebApp.Domain.Entities;

/// <summary>
/// Represents a sales transaction.
/// </summary>
public class Sale : Entity<Guid>, ISale
{
    /// <summary>
    /// Gets or sets the ID of the client associated with the sale.
    /// </summary>
    public Guid ClientId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the date of the sale.
    /// </summary>
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the client associated with the sale.
    /// </summary>
    public Client? Client { get; set; }

    /// <summary>
    /// Implementation of <see cref="ISale.Client"/>
    /// </summary>
    IClient? ISale.Client { get => Client; set => Client = (Client?)value; }

    /// <summary>
    /// Gets or sets the list of items included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = [];

    /// <summary>
    /// Implementation of <see cref="ISale.Items"/>
    /// </summary>
    List<ISaleItem> ISale.Items { get => [.. Items.Select(x => (ISaleItem)x)]; set => Items = [.. value.Select(x => (SaleItem)x)]; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class with default values.
    /// </summary>
    public Sale() : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class with a specified ID.
    /// </summary>
    /// <param name="id"></param>
    public Sale(Guid? id) : base(id ?? Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class with null values.
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="saleDate"></param>
    /// <param name="items"></param>
    /// <param name="id"></param>
    /// <param name="client"></param>
    public Sale(Guid clientId, DateTime saleDate,
    List<SaleItem>? items = null, Guid? id = null, Client? client = null) : this(id)
        => (ClientId, SaleDate, Items, Client) = (clientId, saleDate, items ?? [], client);
}