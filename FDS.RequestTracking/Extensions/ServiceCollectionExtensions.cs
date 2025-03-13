using FDS.RequestTracking.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace FDS.RequestTracking.Extensions;

/// <summary>
/// Extension to simplify the injection of RequestDataFilter.
/// </summary>
public static class ServiceCollectionExtensions
{

    /// <summary>
    /// Adds the RequestDataFilter to the service collection for dependency injection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the filter to.</param>
    /// <returns>The updated IServiceCollection instance.</returns>    
    public static IServiceCollection AddRequestTracking(this IServiceCollection services)
    {
        services.AddScoped<RequestDataFilter>();
        return services;
    }
}
