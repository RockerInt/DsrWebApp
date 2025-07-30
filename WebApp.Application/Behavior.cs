using Dsr.Architecture.Application.Exceptions;
using Dsr.Architecture.Application.UseCases;
using Dsr.Architecture.Domain.Entities;
using Dsr.Architecture.Application.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace WebApp.Application;

/// <summary>
/// Central excecution manager of MediatR for UseCases
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <param name="validators">Collection of validators for the request</param>
/// <param name="logger">Logger instance for logging information and errors</param>
public class Behavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators, ILogger<Behavior<TRequest, TResponse>> logger)
    : UseCaseBehavior<TRequest, TResponse>(validators, logger)
    where TRequest : IUseCase<TResponse>
    where TResponse : Result
{
}