using UuidGenerator = FDS.UuidV7.NetCore.UuidV7;
using System.Text.Json;
using System.Text.Json.Serialization;
using FDS.DbLogger.PostgreSQL.Published;

namespace FDS.DbLogger.PostgreSQL.Domain.Entities;

/// <summary>
/// Represents an audit log entry.
/// </summary>
internal class AuditLog
{
    public Guid Id { get; private set; }
    public DateTime EventTimestamp { get; private set; }
    public string EventAction { get; private set; }
    public string ContextName { get; private set; }
    public int? HttpStatusCode { get; private set; }
    public string? EventMessage { get; private set; }
    public Guid? UserId { get; private set; }

    [JsonIgnore]
    public string? RequestData { get; private set; }

    [JsonIgnore]
    public string? ResponseData { get; private set; }

    private AuditLog()
    {
        EventAction = LogActionType.INFO.Value;
        ContextName = "Unknown";
    }

    public AuditLog(
        LogActionType eventAction,
        string contextName,
        string? eventMessage,
        object? requestData,
        object? responseData,
        int? httpStatusCode = null,
        Guid? userId = null)
    {
        Id = UuidGenerator.Generate();
        EventTimestamp = DateTime.UtcNow;
        EventAction = eventAction.Value;
        ContextName = contextName;
        HttpStatusCode = httpStatusCode;
        UserId = userId;
        EventMessage = eventMessage;
        RequestData = requestData != null ? JsonSerializer.Serialize(requestData) : null;
        ResponseData = responseData != null ? JsonSerializer.Serialize(responseData) : null;
    }
}
