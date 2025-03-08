using FDS.DbLogger.PostgreSQL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FDS.DbLogger.PostgreSQL.Domain.Interfaces;

/// <summary>
/// Interface for the Audit Log DbContext, allowing integration with external projects.
/// </summary>
public interface IAuditLogDbContext
{
    DbSet<AuditLog> AuditLogs { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
