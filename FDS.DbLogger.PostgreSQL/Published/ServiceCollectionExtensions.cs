using FDS.DbLogger.PostgreSQL.Application.Services;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using FDS.DbLogger.PostgreSQL.Infrastructure;
using FDS.DbLogger.PostgreSQL.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FDS.DbLogger.PostgreSQL.Published;

/// <summary>
/// Dependency Injection Configuration for FDS.DbLogger.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the AuditLogDbContext and related services in the DI container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="connectionString">The database connection string.</param>
    /// <param name="contextName">An optional name for the logging context.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddDbLogger(
        this IServiceCollection services,
        string connectionString,
        string contextName = "default")
    {
        // Receives the connection string and creates the context internally.
        services.AddDbContext<AuditLogDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IAuditLogRepository, AuditLogRepository>();

        services.AddScoped<Func<string, IAuditLogService>>(provider => contextName =>
        {
            var repository = provider.GetRequiredService<IAuditLogRepository>();
            var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
            return new AuditLogService(repository, contextName, httpContextAccessor);
        });

        return services;
    }
}
