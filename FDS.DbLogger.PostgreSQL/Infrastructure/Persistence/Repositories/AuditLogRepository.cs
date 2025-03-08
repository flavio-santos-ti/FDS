using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FDS.DbLogger.PostgreSQL.Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository for handling audit log operations.
/// </summary>
public class AuditLogRepository : IAuditLogRepository
{
    private readonly IAuditLogDbContext _context;

    public AuditLogRepository(IAuditLogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AuditLog auditLog)
    {
        await _context.AuditLogs.AddAsync(auditLog);
        await _context.SaveChangesAsync();
    }
}
