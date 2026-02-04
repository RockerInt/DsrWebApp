using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;

using WebApp.Domain.Interfaces.Domain.Entities;

namespace WebApp.Domain.Entities;

/// <summary>
/// Represents an item within a sales transaction.
/// </summary>
public class SaleItem : Entity<Guid>, ISaleItem
{
    /// <summary>
    /// Gets or sets the ID of the sale.
    /// </summary>
    public Guid? SaleId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the ID of the product sold.
    /// </summary>
    public Guid ProductId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; } 

    /// <summary>
    /// Gets or sets the unit price of the product at the time of sale.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this sale item.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Implementation of <see cref="ISaleItem.Product"/>
    /// </summary>
    IProduct? ISaleItem.Product { get => Product; set => Product = (Product?)value; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SaleItem"/> class with default values.
    /// </summary>
    public SaleItem() : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleItem"/> class with a specified ID.
    /// </summary>
    /// <param name="id"></param>
    public SaleItem(Guid? id) : base(id ?? Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleItem"/> class with default values.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <param name="unitPrice"></param>
    /// <param name="id"></param>
    /// <param name="saleId"></param>
    /// <param name="product"></param>
    public SaleItem(Guid productId, int quantity, decimal unitPrice, 
    Guid? id = default, Guid? saleId = default, Product? product = null) : this(id)
        => (ProductId, Quantity, UnitPrice, SaleId, Product) = (productId, quantity, unitPrice, saleId, product);

}
