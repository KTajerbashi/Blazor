namespace CleanArchitectureBlazor.WebApp.Middlewares.ExceptionHandler;

// API Response Models
public class ApiExceptionResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ErrorMessage { get; set; }
    public string? Details { get; set; }

    public ApiExceptionResponse(int statusCode, string message, string? details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }

    public ApiExceptionResponse(int statusCode)
    {
        StatusCode = statusCode;
        Message = GetDefaultMessage(statusCode);
    }

    private static string GetDefaultMessage(int statusCode) =>
        statusCode switch
        {
            400 => "Bad Request",
            401 => "Unauthorized",
            404 => "Resource Not Found",
            422 => "Validation Error",
            500 => "Internal Server Error",
            _ => "An error occurred"
        };
}