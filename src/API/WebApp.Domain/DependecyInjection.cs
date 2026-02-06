using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Domain;

/// <summary>
/// Provides extension methods for dependency injection in the Domain layer.
/// </summary>
public static class DependecyInjection
{
    /// <summary>
    /// Adds domain-specific services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddDomain(this IServiceCollection services)
        => services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}
