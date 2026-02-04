using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using WebApp.Domain.Enums;

namespace WebApp.Domain.Interfaces.Application.UseCases.Commands;

/// <summary>
/// Represents the use case for registering a new product.
/// </summary>
public class RegisterProductUseCase(string name, string description, decimal price, int stock) : UseCase<ResultSimple>()
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = name;
    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = description;
    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; } = price;
    /// <summary>
    /// Gets or sets the stock quantity of the product.
    /// </summary>
    public int Stock { get; set; } = stock;
}
