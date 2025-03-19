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
        object? requestData = null,
        object? responseData = null,
        Guid? userId = null)
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
            requestData: requestData,
            responseData: responseData,
            httpStatusCode: httpStatusCode,
            userId: userId
        );

        await _repository.AddAsync(auditLog);
    }

    /// <summary>
    /// Logs a validation error event.
    /// </summary>
    public async Task LogValidationErrorAsync(string eventMessage, object? requestData = null, Guid? userId = null)
    {
        var auditLog = new AuditLog(
            eventAction: LogActionType.VALIDATION_ERROR,
            contextName: _contextName,
            eventMessage: eventMessage,
            requestData: requestData, 
            responseData: null,
            httpStatusCode: 400,
            userId: userId
        );

        await _repository.AddAsync(auditLog);
    }

    /// <summary>
    /// Logs an informational event.
    /// </summary>
    public async Task LogInfoAsync(string eventMessage, object? requestData = null, Guid? userId = null)
    {
        var auditLog = new AuditLog(
            eventAction: LogActionType.INFO,
            contextName: _contextName,
            eventMessage: eventMessage,
            requestData: requestData,
            responseData: null, 
            httpStatusCode: 200,
            userId: userId
        );

        await _repository.AddAsync(auditLog);
    }

    /// <summary>
    /// Logs a create action event.
    /// </summary>
    public async Task LogCreateAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null)
    {
        await LogAsync(LogActionType.CREATE, eventMessage, requestData, responseData, userId);
    }
}
