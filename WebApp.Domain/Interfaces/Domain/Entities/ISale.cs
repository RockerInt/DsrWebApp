using Dsr.Architecture.Domain.Interfaces;

namespace WebApp.Domain.Interfaces.Domain.Entities;

/// <summary>
/// Represents a sales transaction.
/// </summary>
public interface ISale : IEntity<Guid>
{
    /// <summary>
    /// Gets or sets the ID of the client associated with the sale.
    /// </summary>
    public Guid ClientId { get; set; } 
    /// <summary>
    /// Gets or sets the date of the sale.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets or sets the client associated with the sale.
    /// </summary>
    public IClient? Client { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the sale.
    /// </summary>
    public List<ISaleItem> Items { get; set; }
}
