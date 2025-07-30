using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;

using WebApp.Domain.Interfaces.Domain.Entities;

namespace WebApp.Domain.Entities;

/// <summary>
/// Represents a product in the inventory system.
/// </summary>
public class Product : Entity<Guid>, IProduct 
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; } 
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with default values.
    /// </summary>
    public Product() : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with a specified ID.
    /// </summary>
    /// <param name="id"></param>
    public Product(Guid? id) : base(id ?? Guid.NewGuid())
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with default values.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="price"></param>
    /// <param name="id"></param>
    public Product(string name, string description, decimal price, Guid? id = null) : this(id)
        => (Name, Description, Price) = (name, description, price);

}