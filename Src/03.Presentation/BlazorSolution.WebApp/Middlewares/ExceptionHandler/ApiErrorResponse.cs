using System.Net;

namespace BlazorSolution.WebApp.Middlewares.ExceptionHandler;

public class ApiErrorResponse
{
    public int StatusCode { get; }
    public string Message { get; }
    public string? StackTrace { get; }
    public string? TraceId { get; }
    public DateTime Timestamp { get; } = DateTime.UtcNow;

    public ApiErrorResponse(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }

    public ApiErrorResponse(
        HttpStatusCode statusCode,
        string message,
        string? stackTrace,
        string? traceId) : this(statusCode, message)
    {
        StackTrace = stackTrace;
        TraceId = traceId;
    }
}