namespace FDS.DbLogger.PostgreSQL.Published;

/// <summary>
/// Service for logging audit events.
/// </summary>
public interface IAuditLogService
{
    /// <summary>
    /// Logs an event asynchronously.
    /// </summary>
    Task LogAsync(LogActionType eventAction, string eventMessage, object? requestData = null, object? responseData = null, string? userEmail = null);

    /// <summary>
    /// Logs a validation error event.
    /// </summary>
    Task LogValidationErrorAsync(string eventMessage, object? requestData = null, string? userEmail = null);

    /// <summary>
    /// Logs an informational event.
    /// </summary>
    Task LogInfoAsync(string eventMessage, object? requestData = null, string? userEmail = null);

    /// <summary>
    /// Logs a create action event.
    /// </summary>
    Task LogCreateAsync(string eventMessage, object? requestData = null, object? responseData = null, string? userEmail = null);
}
