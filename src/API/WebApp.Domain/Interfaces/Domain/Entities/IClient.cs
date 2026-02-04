using Dsr.Architecture.Domain.Interfaces;

namespace WebApp.Domain.Interfaces.Domain.Entities;

/// <summary>
/// Represents a client in the sales system.
/// </summary>
public interface IClient : IEntity<Guid>
{
    /// <summary>
    /// Gets or sets the name of the client.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the email of the client.
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Gets or sets the phone number of the client.
    /// </summary>
    public string Phone { get; set; }
}

