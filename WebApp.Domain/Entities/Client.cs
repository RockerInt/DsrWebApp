using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Utilities;
using WebApp.Domain.Interfaces.Domain.Entities;

namespace WebApp.Domain.Entities;

/// <summary>
/// Represents a client in the sales system.
/// </summary>
public class Client : Entity<Guid>, IClient
{
    /// <summary>
    /// Gets or sets the name of the client.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email of the client.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number of the client.
    /// </summary>
    public string Phone { get; set; } = string.Empty;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Client"/> class with default values.
    /// </summary>
    public Client() : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Client"/> class with a specified ID.
    /// </summary>
    /// <param name="id"></param>
    public Client(Guid? id) : base(id ?? Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Client"/> class with dafault values.
    /// </summary>
    /// <param name="name"></param>      
    /// <param name="email"></param>
    /// <param name="phone"></param>
    /// <param name="id"></param>
    public Client(string name, string email, string phone, Guid? id = null) : this(id)
        => (Name, Email, Phone) = (name, email, phone);

}