using Microsoft.Extensions.Logging;
using Polly;
using Polly.Timeout;

namespace WebApp.Server.Resilience;

/// <summary>
/// Provides HTTP resilience policies using Polly.
/// </summary>
public static class HttpPolicies
{
    /// <summary>
    /// Gets a retry policy that retries on HttpRequestException and TimeoutRejectedException.
    /// </summary>
    /// <param name="logger"></param>
    /// <returns></returns>
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(ILogger logger)
    {
        return Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(
                3,
                retryAttempt => TimeSpan.FromMilliseconds(200 * Math.Pow(2, retryAttempt)),
                onRetry: (outcome, timespan, retryCount, context) =>
                    logger.LogWarning(
                        $"Retry {retryCount} implemented after {timespan.TotalMilliseconds}ms due to: {outcome.Exception?.Message}"));
    }

    /// <summary>
    /// Gets a circuit breaker policy that breaks the circuit after a specified number of exceptions.
    /// </summary>
    /// <param name="logger"></param>
    /// <returns></returns>
    public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(ILogger logger)
    {
        return Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .CircuitBreakerAsync(
                5,
                TimeSpan.FromSeconds(30),
                onBreak: (outcome, breakDelay) =>
                    logger.LogWarning("Circuit breaker opened"),
                onReset: () =>
                    logger.LogInformation("Circuit breaker closed"),
                onHalfOpen: () =>
                    logger.LogInformation("Circuit breaker half-open"));
    }

    /// <summary>
    /// Gets a combined resilience policy with retry and circuit breaker.     
    /// </summary>
    /// <param name="logger"></param>
    /// <returns></returns>
    public static IAsyncPolicy<HttpResponseMessage> GetResiliencePolicy(ILogger logger)
    {
        // rety first, then circuit breaker
        return Policy.WrapAsync(
            GetRetryPolicy(logger),
            GetCircuitBreakerPolicy(logger)
        );
    }
}