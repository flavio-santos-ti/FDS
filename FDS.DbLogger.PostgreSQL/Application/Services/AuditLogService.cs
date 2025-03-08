using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using FDS.DbLogger.PostgreSQL.Types;

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
}
