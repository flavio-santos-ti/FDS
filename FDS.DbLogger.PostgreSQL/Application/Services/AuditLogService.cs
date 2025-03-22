using FDS.DbLogger.PostgreSQL.Domain.Entities;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using FDS.DbLogger.PostgreSQL.Published;
using FDS.RequestTracking.Storage;
using Microsoft.AspNetCore.Http;

namespace FDS.DbLogger.PostgreSQL.Application.Services;

/// <summary>
/// Service for handling audit log operations.
/// </summary>
internal class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _repository;
    private readonly string _contextName;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditLogService(IAuditLogRepository repository, string contextName, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _contextName = contextName;
        _httpContextAccessor = httpContextAccessor;
    }

    private async Task<string> LogAsync(
        LogActionType eventAction,
        string eventMessage,
        object? requestData = null,
        object? responseData = null,
        Guid? userId = null)
    {
        int httpStatusCode;
        
        if (eventAction == LogActionType.INFO)
            httpStatusCode = 100;
        else if (eventAction == LogActionType.VALIDATION_ERROR)
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

        var traceIdentifier = _httpContextAccessor.HttpContext?.TraceIdentifier ?? "N/A";

        string requestMethod = "UNKNOWN";
        string requestPath = "UNKNOWN";
        if (!string.IsNullOrEmpty(traceIdentifier))
        {
            var request = RequestDataStorage.GetData(traceIdentifier);

            if (request is not null)
            {
                requestMethod = request.Method;
                requestPath = request.Path;
            }
        }

        var auditLog = new AuditLog(
            eventAction: eventAction,
            contextName: _contextName,
            httpMethod: requestMethod,
            requestPath: requestPath,
            eventMessage: eventMessage,
            requestData: requestData,
            responseData: responseData,
            traceIdentifier: traceIdentifier,
            httpStatusCode: httpStatusCode,
            userId: userId 
        );

        await _repository.AddAsync(auditLog);

        return traceIdentifier;
    }

    /// <summary>
    /// Logs a validation error event.
    /// </summary>
    public async Task<string> LogValidationErrorAsync(string eventMessage, object? requestData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.VALIDATION_ERROR, eventMessage, requestData, responseData: null, userId);
    }

    /// <summary>
    /// Logs an informational event.
    /// </summary>
    public async Task<string> LogInfoAsync(string eventMessage, object? requestData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.INFO, eventMessage, requestData, responseData: null, userId);
    }

    /// <summary>
    /// Logs a create action event.
    /// </summary>
    public async Task<string> LogCreateAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.CREATE, eventMessage, requestData, responseData, userId);
    }

    /// <summary>
    /// Logs a not found event.
    /// </summary>
    public async Task<string> LogNotFoundAsync(string eventMessage, object? requestData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.NOT_FOUND, eventMessage, requestData, responseData: null, userId);
    }

    /// <summary>
    /// Logs an error event.
    /// </summary>
    public async Task<string> LogErrorAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.ERROR, eventMessage, requestData, responseData, userId);
    }

    /// <summary>
    /// Logs a login creation event.
    /// </summary>
    public async Task<string> LogCreateLoginAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.CREATE_LOGIN, eventMessage, requestData, responseData, userId);
    }

    /// <summary>
    /// Logs an upload creation event.
    /// </summary>
    public async Task<string> LogCreateUploadAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.CREATE_UPLOAD, eventMessage, requestData, responseData, userId);
    }

    /// <summary>
    /// Logs a delete action event.
    /// </summary>
    public async Task<string> LogDeleteAsync(string eventMessage, Guid? userId = null)
    {
        return await LogAsync(LogActionType.DELETE, eventMessage, null, null, userId);
    }

    /// <summary>
    /// Logs a read action event.
    /// </summary>
    public async Task<string> LogReadAsync(string eventMessage, object? responseData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.READ, eventMessage, null, responseData, userId);
    }

    /// <summary>
    /// Logs an update action event.
    /// </summary>
    public async Task<string> LogUpdateAsync(string eventMessage, object? requestData = null, object? responseData = null, Guid? userId = null)
    {
        return await LogAsync(LogActionType.UPDATE, eventMessage, requestData, responseData, userId);
    }
}
