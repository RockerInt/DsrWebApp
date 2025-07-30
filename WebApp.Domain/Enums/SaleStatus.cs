using System.ComponentModel;

namespace WebApp.Domain.Enums;

/// <summary>
/// Represents the possible statuses of a sales transaction.
/// </summary>
public enum SaleStatus
{
    /// <summary>
    /// The sale is pending.
    /// </summary>
    [Description("Pending")]
    Pending = 1,
    /// <summary>
    /// The sale has been completed.
    /// </summary>
    [Description("Completed")]
    Completed = 2,
    /// <summary>
    /// The sale has been cancelled.
    /// </summary>
    [Description("Cancelled")]
    Cancelled = 3,
}