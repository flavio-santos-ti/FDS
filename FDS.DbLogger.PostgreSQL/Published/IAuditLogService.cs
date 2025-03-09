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

    /// <summary>
    /// Logs a validation error event asynchronously.
    /// </summary>
    /// <param name="eventMessage">The validation error message.</param>
    /// <param name="dataRequest">Optional data related to the request that triggered the validation error.</param>
    /// <param name="userEmail">Optional email of the user associated with the request.</param>
    Task LogValidationErrorAsync(string eventMessage, object? dataRequest = null, string? userEmail = null);
}
