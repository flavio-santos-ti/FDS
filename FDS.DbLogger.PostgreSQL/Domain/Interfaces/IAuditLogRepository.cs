using FDS.DbLogger.PostgreSQL.Domain.Entities;

namespace FDS.DbLogger.PostgreSQL.Domain.Interfaces;

/// <summary>
/// Interface for Audit Log Repository.
/// </summary>
public interface IAuditLogRepository
{
    Task AddAsync(AuditLog auditLog);
}
