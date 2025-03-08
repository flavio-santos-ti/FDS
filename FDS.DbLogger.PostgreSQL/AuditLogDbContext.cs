using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using FDS.DbLogger.PostgreSQL.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FDS.DbLogger.PostgreSQL;

/// <summary>
/// Database context for audit logging.
/// </summary>
public class AuditLogDbContext : DbContext, IAuditLogDbContext
{
    public DbSet<AuditLog> AuditLogs { get; set; }

    public AuditLogDbContext(DbContextOptions<AuditLogDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuditLogMap).Assembly);
    }
}
