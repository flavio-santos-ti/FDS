namespace FDS.DbLogger.PostgreSQL.Published;

/// <summary>
/// Service for logging audit events.
/// </summary>
public interface IAuditLogService
{
    /// <summary>
    /// Logs an event asynchronously.
    /// </summary>
    Task<string> LogAsync(LogActionType eventAction, string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null);

    /// <summary>
    /// Logs a validation error event.
    /// </summary>
    Task<string> LogValidationErrorAsync(string eventMessage, object? requestData = null, Guid? userId = null);

    /// <summary>
    /// Logs an informational event.
    /// </summary>
    Task<string> LogInfoAsync(string eventMessage, object? requestData = null, Guid? userId = null);

    /// <summary>
    /// Logs a create action event.
    /// </summary>
    Task<string> LogCreateAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null);
}
