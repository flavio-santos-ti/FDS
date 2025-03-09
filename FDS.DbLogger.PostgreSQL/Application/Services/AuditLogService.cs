using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using FDS.DbLogger.PostgreSQL.Published;

namespace FDS.DbLogger.PostgreSQL.Application.Services;

/// <summary>
/// Service for handling audit log operations.
/// </summary>
internal class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _repository;
    private readonly string _contextName;

    public AuditLogService(IAuditLogRepository repository, string contextName)
    {
        _repository = repository;
        _contextName = contextName;
    }

    public async Task LogAsync(
        LogActionType eventAction, 
        string eventMessage, 
        object? eventData = null, 
        string? userEmail = null)
    {
        int httpStatusCode;

        if (eventAction == LogActionType.VALIDATION_ERROR)
            httpStatusCode = 400;
        else if (eventAction == LogActionType.NOT_FOUND)
            httpStatusCode = 404;
        else if (eventAction == LogActionType.ERROR)
            httpStatusCode = 500;
        else if (eventAction == LogActionType.CREATE ||
                 eventAction == LogActionType.CREATE_LOGIN ||
                 eventAction == LogActionType.CREATE_UPLOAD)
            httpStatusCode = 201;
        else
            httpStatusCode = 200;

        var auditLog = new AuditLog(
            eventAction: eventAction,
            contextName: _contextName,
            eventMessage: eventMessage,
            eventData: eventData,
            httpStatusCode: httpStatusCode,
            userEmail: userEmail
        );

        await _repository.AddAsync(auditLog);
    }

    /// <summary>
    /// Logs a validation error event.
    /// </summary>
    /// <param name="eventMessage">The error message.</param>
    /// <param name="requestData">Optional data related to the validation error.</param>
    /// <param name="userEmail">Optional user email associated with the request.</param>
    public async Task LogValidationErrorAsync(string eventMessage, object? requestData = null, string? userEmail = null)
    {
        var auditLog = new AuditLog(
            eventAction: LogActionType.VALIDATION_ERROR,
            contextName: _contextName,
            eventMessage: eventMessage,
            eventData: requestData, // Agora está mais descritivo
            httpStatusCode: 400,
            userEmail: userEmail
        );

        await _repository.AddAsync(auditLog);
    }
}
