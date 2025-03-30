using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using Serilog.Sinks.MSSqlServer;
using static Dapper.SqlMapper;
using Serilog.Context;

namespace BlazorSolution.WebApp.Common.Serilog;

public static class SerilogProviderExtensions
{
    public static WebApplicationBuilder AddSerilogServices(this WebApplicationBuilder builder)
    {
        // Configure Serilog
        //builder.Host.UseSerilog((context, configuration) =>
        //{
        //    configuration
        //        .ReadFrom.Configuration(context.Configuration) // Read from appsettings.json
        //        .Enrich.FromLogContext();
        //});
        builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
            .ReadFrom.Configuration(hostingContext.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console());
        return builder;
    }

    public static WebApplication UseSerilogServices(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            using (LogContext.PushProperty("UserIp", context.Connection.RemoteIpAddress))
            using (LogContext.PushProperty("UserAgent", context.Request.Headers["User-Agent"].ToString()))
            using (LogContext.PushProperty("UserId", context.User.FindFirst("sub")?.Value ?? "Anonymous"))
            using (LogContext.PushProperty("UserRoleId", context.User.FindFirst("role")?.Value ?? "Unknown"))
            {
                await next();
            }
        });

        return app;
    }
}
