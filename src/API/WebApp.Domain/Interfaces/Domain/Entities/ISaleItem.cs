using Dsr.Architecture.Domain.Interfaces;

namespace WebApp.Domain.Interfaces.Domain.Entities;

/// <summary>
/// Represents an item within a sales transaction.
/// </summary>
public interface ISaleItem : IEntity<Guid>
{
    /// <summary>
    /// Gets or sets the ID of the sale.
    /// </summary>
    public Guid? SaleId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the product sold.
    /// </summary>
    public Guid ProductId { get; set; }

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
    public IProduct? Product { get; set; } 
}