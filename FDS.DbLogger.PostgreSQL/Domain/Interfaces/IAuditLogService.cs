using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Types;

namespace FDS.DbLogger.PostgreSQL.Domain.Interfaces;

/// <summary>
/// Service for logging audit events.
/// </summary>
public interface IAuditLogService
{
    /// <summary>
    /// Logs an event asynchronously.
    /// </summary>
    Task LogAsync(LogActionType eventAction, string eventMessage, object? eventData = null, string? userEmail = null);
}
