using FDS.NetCore.ApiResponse.Types;
using System.Text.Json.Serialization;

namespace FDS.NetCore.ApiResponse.Models;

/// <summary>
/// Represents a standardized response object for API responses.
/// </summary>
/// <typeparam name="T">The type of data contained in the response.</typeparam>
public class Response<T>
{
    /// <summary>
    /// Internal action type used for internal processing but hidden from API consumers.
    /// </summary>
    [JsonIgnore] // Hides the property in the output JSON..
    public ActionType ActionType { get; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Provides a message describing the result of the request.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// HTTP status code of the response.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// Contains the response data if available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T? Data { get; }

    /// <summary>
    /// Internal constructor to enforce controlled instantiation within the same assembly.
    /// </summary>
    /// <param name="actionType">The internal action type.</param>
    /// <param name="isSuccess">Indicates if the operation was successful.</param>
    /// <param name="message">Message describing the result.</param>
    /// <param name="statusCode">HTTP status code of the response.</param>
    /// <param name="data">Optional response data.</param>
    // Internal constructor: only classes within the same assembly can instantiate it.
    internal Response(ActionType actionType, bool isSuccess, string message, int statusCode, T? data = default)
    {
        ActionType = actionType;
        IsSuccess = isSuccess;
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }
}
