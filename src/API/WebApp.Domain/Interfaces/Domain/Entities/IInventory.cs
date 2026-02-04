using Dsr.Architecture.Domain.Interfaces;

namespace WebApp.Domain.Interfaces.Domain.Entities;

/// <summary>
/// Represents the inventory level for a specific product.
/// </summary>
public interface IInventory : IEntity<Guid>
{
    /// <summary>
    /// Gets or sets the ID of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product currently in stock.
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this inventory item.
    /// </summary>
    public IProduct? Product { get; set; }
}


