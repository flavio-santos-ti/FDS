using FDS.RequestTracking.Models;

namespace FDS.RequestTracking.Storage;

/// <summary>
/// Temporarily stores HTTP request data.
/// </summary>
public static class RequestDataStorage
{
    private static readonly Dictionary<string, RequestDataModel> _requestData = new();

    /// <summary>
    /// Adds request data to the temporary storage.
    /// </summary>
    /// <param name="requestData">The HTTP request data to be stored.</param>
    public static void AddData(RequestDataModel requestData)
    {
        if (!_requestData.ContainsKey(requestData.RequestId))
        {
            _requestData[requestData.RequestId] = requestData;
        }
    }

    /// <summary>
    /// Retrieves the stored HTTP request data using the request ID.
    /// </summary>
    /// <param name="requestId">The unique identifier of the HTTP request.</param>
    /// <returns>The stored request data if found; otherwise, null.</returns>
    public static RequestDataModel? GetData(string requestId)
    {
        return _requestData.TryGetValue(requestId, out var requestData) ? requestData : null;
    }

    /// <summary>
    /// Removes the stored request data associated with the given request ID.
    /// </summary>
    /// <param name="requestId">The unique identifier of the HTTP request to be removed.</param>
    public static void ClearData(string requestId)
    {
        _requestData.Remove(requestId);
    }
}
