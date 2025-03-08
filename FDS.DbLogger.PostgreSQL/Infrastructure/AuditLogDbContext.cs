using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FDS.DbLogger.PostgreSQL.Infrastructure;

/// <summary>
/// Database context for audit logging.
/// </summary>
internal class AuditLogDbContext : DbContext
{
    internal DbSet<AuditLog> AuditLogs { get; set; }

    public AuditLogDbContext(DbContextOptions<AuditLogDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuditLogMap).Assembly);
    }
}
