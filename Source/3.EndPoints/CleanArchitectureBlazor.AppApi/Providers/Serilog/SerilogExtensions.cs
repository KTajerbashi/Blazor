using Serilog;

namespace CleanArchitectureBlazor.AppApi.Providers.Serilog;

public static class SerilogExtensions
{
    public static WebApplicationBuilder AddSerilogService(this WebApplicationBuilder builder, IConfiguration configuration, string sectionName)
    {
        builder.Host.UseSerilog(Log.Logger);

        return builder;
    }
    //  Active Seq For Log

}
