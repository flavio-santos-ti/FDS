namespace FDS.DbLogger.PostgreSQL.Published;

/// <summary>
/// Service for logging audit events.
/// </summary>
public interface IAuditLogService
{
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

    /// <summary>
    /// Logs a not found event.
    /// </summary>
    Task<string> LogNotFoundAsync(string eventMessage, object? requestData = null, Guid? userId = null);

    /// <summary>
    /// Logs an error event.
    /// </summary>
    Task<string> LogErrorAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null);

    /// <summary>
    /// Logs a login creation event.
    /// </summary>
    Task<string> LogCreateLoginAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null);

    /// <summary>
    /// Logs an upload creation event.
    /// </summary>
    Task<string> LogCreateUploadAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null);

    /// <summary>
    /// Logs a delete action event.
    /// </summary>
    Task<string> LogDeleteAsync(string eventMessage, Guid? userId = null);
}
