using System.Diagnostics;
using System.Text;

namespace CleanArchitectureBlazor.WebApp.Middlewares.LoggingHandler;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Log the incoming request
        var request = await FormatRequest(context.Request);
        _logger.LogInformation("Incoming Request: {RequestMethod} {RequestPath}\n{RequestHeaders}\n{RequestBody}",
            context.Request.Method,
            context.Request.Path,
            context.Request.Headers,
            request);

        // Copy the original response body stream
        var originalResponseBodyStream = context.Response.Body;

        // Create a new memory stream to capture the response
        using (var responseBodyStream = new MemoryStream())
        {
            context.Response.Body = responseBodyStream;

            // Call the next middleware in the pipeline
            await _next(context);

            // Log the outgoing response
            stopwatch.Stop();
            var response = await FormatResponse(context.Response);
            _logger.LogInformation("Outgoing Response: {StatusCode} in {ElapsedMilliseconds}ms\n{ResponseHeaders}\n{ResponseBody}",
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds,
                context.Response.Headers,
                response);

            // Copy the captured response back to the original stream
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            await responseBodyStream.CopyToAsync(originalResponseBodyStream);
        }
    }

    private async Task<string> FormatRequest(HttpRequest request)
    {
        request.EnableBuffering(); // Enable rewinding the request body stream

        var body = request.Body;
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer, 0, buffer.Length);
        var bodyAsText = Encoding.UTF8.GetString(buffer);

        // Reset the request body stream position so the next middleware can read it
        request.Body.Seek(0, SeekOrigin.Begin);

        return bodyAsText;
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin); // Reset the stream position for further use
        return bodyAsText;
    }
}

public static class LoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingMiddleware>();
    }
}