using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using WebApp.Domain.Interfaces.Domain.Entities;

namespace WebApp.Domain.Entities;

/// <summary>
/// Represents the inventory level for a specific product.
/// </summary>
public class Inventory : Entity<Guid>, IInventory
{
    /// <summary>
    /// Gets or sets the ID of the product.
    /// </summary>
    public Guid ProductId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product currently in stock.
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this inventory item.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Implementation of <see cref="IInventory.Product"/>
    /// </summary>
    IProduct? IInventory.Product { get => Product; set => Product = (Product?)value; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Inventory"/> class with default values.
    /// </summary>
    public Inventory() : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Inventory"/> class with a specified ID.
    /// </summary>
    /// <param name="id"></param>
    public Inventory(Guid? id) : base(id ?? Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Inventory"/> class with default values.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="stockQuantity"></param>
    /// <param name="id"></param>
    /// <param name="product"></param>
    public Inventory(Guid productId, int stockQuantity, Guid? id = null, Product? product = null) : this(id)
        => (ProductId, StockQuantity, Product) = (productId, stockQuantity, product);
}
