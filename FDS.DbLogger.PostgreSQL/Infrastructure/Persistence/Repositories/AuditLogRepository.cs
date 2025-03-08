using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;

namespace FDS.DbLogger.PostgreSQL.Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository for handling audit log operations.
/// </summary>
internal class AuditLogRepository : IAuditLogRepository
{
    private readonly AuditLogDbContext _context; // Agora usa diretamente AuditLogDbContext

    public AuditLogRepository(AuditLogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AuditLog auditLog)
    {
        await _context.AuditLogs.AddAsync(auditLog);
        await _context.SaveChangesAsync();
    }
}
