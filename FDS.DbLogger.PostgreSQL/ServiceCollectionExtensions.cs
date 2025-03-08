using FDS.DbLogger.PostgreSQL.Application.Interfaces;
using FDS.DbLogger.PostgreSQL.Application.Services;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using FDS.DbLogger.PostgreSQL.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FDS.DbLogger.PostgreSQL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbLogger<TContext>(this IServiceCollection services, string contextName = "default")
        where TContext : DbContext, IAuditLogDbContext
    {

        // Registra o contexto de banco de dados
        services.AddScoped<IAuditLogDbContext>(provider =>
            provider.GetRequiredService<TContext>());

        services.AddScoped<IAuditLogRepository, AuditLogRepository>();

        services.AddScoped<IAuditLogService>(provider =>
        {
            var repository = provider.GetRequiredService<IAuditLogRepository>();
            return new AuditLogService(repository, contextName);
        });

        services.AddScoped<IAuditLogServiceFactory, AuditLogServiceFactory>();

        return services;
    }
}
