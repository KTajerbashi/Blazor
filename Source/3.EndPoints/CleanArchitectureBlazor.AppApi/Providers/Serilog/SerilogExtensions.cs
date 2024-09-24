using Serilog;
using Serilog.Context;
using Serilog.Sinks.MSSqlServer;

namespace CleanArchitectureBlazor.AppApi.Providers.Serilog;

public static class SerilogExtensions
{
    public static WebApplicationBuilder AddSerilogService(this WebApplicationBuilder builder, IConfiguration configuration, string sectionName)
    {
        builder.Services.AddSerilog(option =>
        {
            option.ReadFrom.Configuration(configuration);
        });

        builder.Host.UseSerilog((context, lc) =>
            lc.WriteTo.Console()
              .WriteTo.File("./LoggerFiles/log.txt", rollingInterval: RollingInterval.Day)
              .WriteTo.MSSqlServer(
                context.Configuration["ConnectionStrings:DefaultConnection"],
                sinkOptions: new MSSqlServerSinkOptions { SchemaName = "Log", TableName = "Logs" })
              .ReadFrom.Configuration(configuration)
            );
        return builder;
    }
    //  Active Seq For Log
    public static WebApplication UseSerilog(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            var correlationId = context.Request.Headers["X-Correlation-ID"].FirstOrDefault() ?? Guid.NewGuid().ToString();
            context.Response.Headers["X-Correlation-ID"] = correlationId;

            using (LogContext.PushProperty("CorrelationID", correlationId))
            {
                await next();
            }
        });
        return app;
    }

}
