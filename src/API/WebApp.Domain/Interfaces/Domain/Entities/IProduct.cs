using Dsr.Architecture.Domain.Interfaces;

namespace WebApp.Domain.Interfaces.Domain.Entities;

/// <summary>
/// Represents a product in the inventory system.
/// </summary>
public interface IProduct : IEntity<Guid> 
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; }

    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; } 
}

