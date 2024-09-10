using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureBlazor.Infrastructure.ApplicationContext;

public class DbContextApplicationFactory : IDesignTimeDbContextFactory<DbContextApplication>
{
    public DbContextApplication CreateDbContext(string[] args)
    {
        // Build configuration
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  // Set base path
            .AddJsonFile("appsettings.json")                // Add default config
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)  // Add environment-specific config
            .AddEnvironmentVariables()                      // Add environment variables
            .Build();

        // Get the connection string
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Build DbContext options
        var optionsBuilder = new DbContextOptionsBuilder<DbContextApplication>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DbContextApplication(optionsBuilder.Options);
    }
}