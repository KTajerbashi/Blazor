using BlazorSolution.WebApp.Extensions;
using NuGet.Protocol;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;
using System.Text;
namespace BlazorSolution.WebApp.Providers.Serilog;

public static class SerilogExtensions
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Services.AddLogging(); // ILogger is usually registered by default


        // Custom console theme with custom colors - defined inline
        var customTheme = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\x1b[38;5;0253m",
                [ConsoleThemeStyle.SecondaryText] = "\x1b[38;5;0246m",
                [ConsoleThemeStyle.TertiaryText] = "\x1b[38;5;0242m",
                [ConsoleThemeStyle.Invalid] = "\x1b[33;1m",
                [ConsoleThemeStyle.Null] = "\x1b[38;5;0038m",
                [ConsoleThemeStyle.Name] = "\x1b[38;5;0081m",
                [ConsoleThemeStyle.String] = "\x1b[38;5;0216m",
                [ConsoleThemeStyle.Number] = "\x1b[38;5;151m",
                [ConsoleThemeStyle.Boolean] = "\x1b[38;5;0038m",
                [ConsoleThemeStyle.Scalar] = "\x1b[38;5;0079m",
                [ConsoleThemeStyle.LevelVerbose] = "\x1b[37m",
                [ConsoleThemeStyle.LevelDebug] = "\x1b[38;5;111m",
                [ConsoleThemeStyle.LevelInformation] = "\x1b[38;5;047m\x1b[48;5;232m",
                [ConsoleThemeStyle.LevelWarning] = "\x1b[38;5;178m\x1b[48;5;232m",
                [ConsoleThemeStyle.LevelError] = "\x1b[38;5;196m\x1b[48;5;232m",
                [ConsoleThemeStyle.LevelFatal] = "\x1b[38;5;196m\x1b[48;5;232m\x1b[1m",
            });

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName() // Now available with Serilog.Enrichers.Environment
            .Enrich.WithThreadId()    // Now available with Serilog.Enrichers.Thread
            .WriteTo.Console(theme: customTheme) // Use the inline theme variable
            .CreateLogger();

        //builder.Host.UseSerilog();

        builder.Host.UseSerilog(Log.Logger, dispose: true);
        return builder;
    }

    public static WebApplication UseSerilog(this WebApplication app)
    {

        app.UseMiddleware<SerilogEnrichmentMiddleware>();
        //app.UseSerilogRequestLogging(opts =>
        //{
        //    opts.MessageTemplate =
        //        "HTTP {RequestMethod} {RequestPath} ({Controller}/{Action}) responded {StatusCode} in {Elapsed:0.0000} ms | Duration: {DurationMs} ms | RequestId: {RequestId}";
        //});

        //app.UseSerilogRequestLogging(opts =>
        //{
        //    opts.MessageTemplate =
        //        "HTTP {RequestMethod} {RequestPath} ({Controller}/{Action}) responded {StatusCode} in {Elapsed:0.0000} ms (RequestId: {RequestId})";
        //});

        app.UseSerilogRequestLogging();

        return app;
    }
}

public class SerilogEnrichmentMiddleware
{
    private readonly RequestDelegate _next;

    public SerilogEnrichmentMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        var requestId = context.TraceIdentifier ?? Guid.NewGuid().ToString();
        var descriptor = context.GetControllerActionNames();

        string controller = descriptor.Controller ?? "N/A";
        string action = descriptor.Action ?? "N/A";
        string httpMethod = context.Request.Method;
        string parameters = string.Empty;

        // ✅ Capture parameters by HTTP method
        if (httpMethod == HttpMethods.Get || httpMethod == HttpMethods.Delete)
        {
            parameters = context.Request.QueryString.HasValue
                ? context.Request.QueryString.Value!
                : context.Request.RouteValues.ToJson();
        }
        else if (httpMethod == HttpMethods.Post || httpMethod == HttpMethods.Put || httpMethod == HttpMethods.Patch)
        {
            parameters = await ReadRequestBodyAsync(context);
        }

        string userId = context.User?.Identity?.IsAuthenticated == true
            ? context.User.Identity?.Name ?? "Unknown"
            : "Anonymous";

        string userIp = context.Connection.RemoteIpAddress?.ToString() ?? "N/A";


        using (LogContext.PushProperty("RequestId", requestId))
        using (LogContext.PushProperty("HttpMethod", httpMethod))
        using (LogContext.PushProperty("Controller", controller))
        using (LogContext.PushProperty("Action", action))
        using (LogContext.PushProperty("Parameters", parameters))
        using (LogContext.PushProperty("UserId", userId))
        using (LogContext.PushProperty("UserIp", userIp))
        {
            await _next(context);

            sw.Stop();


        }
        // Format duration as HH:mm:ss.fff
        string formattedDuration = TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds)
                                        .ToString(@"hh\:mm\:ss\.fff");

        using (LogContext.PushProperty("Duration", formattedDuration))
        using (LogContext.PushProperty("StatusCode", context.Response?.StatusCode))
        {

            // Serilog picks up properties automatically
        }

    }

    private static async Task<string> ReadRequestBodyAsync(HttpContext context)
    {
        context.Request.EnableBuffering();

        using var reader = new StreamReader(
            context.Request.Body,
            Encoding.UTF8,
            detectEncodingFromByteOrderMarks: false,
            bufferSize: 1024,
            leaveOpen: true);

        string body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0; // rewind so controller can still read

        return body;
    }
}