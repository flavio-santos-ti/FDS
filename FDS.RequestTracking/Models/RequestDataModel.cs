namespace FDS.RequestTracking.Models;

/// <summary>
/// Represents the data of an HTTP request temporarily stored.
/// </summary>
public class RequestDataModel
{
    /// <summary>
    /// Unique identifier for the HTTP request.
    /// </summary>
    public string RequestId { get; set; } = string.Empty;

    /// <summary>
    /// HTTP request method (e.g., GET, POST, PUT, DELETE).
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// The URL path of the HTTP request.
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// Query parameters included in the HTTP request.
    /// </summary>
    public string QueryParams { get; set; } = string.Empty;

    /// <summary>
    /// The timestamp indicating when the HTTP request was logged.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
