using FDS.RequestTracking.Models;
using FDS.RequestTracking.Storage;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FDS.RequestTracking.Filters;

/// <summary>
/// Filter to capture and store HTTP request data.
/// </summary>
public class RequestDataFilter : IActionFilter
{
    private readonly ILogger<RequestDataFilter> _logger;


    /// <summary>
    /// Initializes a new instance of the <see cref="RequestDataFilter"/> class.
    /// </summary>
    /// <param name="logger">The logger instance used for request tracking.</param>
    public RequestDataFilter(ILogger<RequestDataFilter> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Called before the action method executes. Captures and logs request data.
    /// </summary>
    /// <param name="context">The context of the executing action, containing HTTP request details.</param>
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var requestId = context.HttpContext.TraceIdentifier;
        var method = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;
        var queryParams = context.HttpContext.Request.QueryString.ToString();

        var requestData = new RequestDataModel
        {
            RequestId = requestId,
            Method = method,
            Path = path,
            QueryParams = queryParams,
            Timestamp = DateTime.UtcNow
        };

        _logger.LogInformation($"[Request Tracking] {method} {path}{queryParams}");

        RequestDataStorage.AddData(requestData);
    }

    /// <summary>
    /// Called after the action method executes, before the action result is returned.
    /// </summary>
    /// <param name="context">The context of the executed action, containing HTTP request and response details.</param>
    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Post-processing logic can be added here if needed.
    }
}
