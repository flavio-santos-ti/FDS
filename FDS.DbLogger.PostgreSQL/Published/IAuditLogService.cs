namespace FDS.DbLogger.PostgreSQL.Published;

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
