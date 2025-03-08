using FDS.DbLogger.PostgreSQL.Domain.Entities;

namespace FDS.DbLogger.PostgreSQL.Domain.Interfaces;

/// <summary>
/// Interface for Audit Log Repository.
/// </summary>
internal interface IAuditLogRepository
{
    internal Task AddAsync(AuditLog auditLog);
}
