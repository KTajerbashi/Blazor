using CleanArchitectureBlazor.Core.Domain.Entities.Privilege;
using CleanArchitectureBlazor.Core.Domain.Entities.Security;
using CleanArchitectureBlazor.Core.Domain.Entities.Setting;
using CleanArchitectureBlazor.Infra.DataSql.BaseInfraData.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureBlazor.Infra.DataSql.Context;

public class DbContextApplication : BaseContext
{
    public DbContextApplication(DbContextOptions<DbContextApplication> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserEntity>().ToTable("Users", "Security");
        builder.Entity<RoleEntity>().ToTable("Roles", "Security");
        builder.Entity<RoleClaimEntity>().ToTable("RoleClaims", "Security");
        builder.Entity<UserClaimEntity>().ToTable("UserClaims", "Security");
        builder.Entity<UserLoginEntity>().ToTable("UserLogins", "Security");
        builder.Entity<UserRoleEntity>().ToTable("UserRoles", "Security");
        builder.Entity<UserTokenEntity>().ToTable("UserTokens", "Security");
    }


    #region Identity DbSet<>
    public virtual DbSet<UserEntity> UserEntities { get; set; }
    public virtual DbSet<RoleEntity> RoleEntities { get; set; }
    public virtual DbSet<UserClaimEntity> UserClaimEntities { get; set; }
    public virtual DbSet<UserRoleEntity> UserRoleEntities { get; set; }
    public virtual DbSet<UserLoginEntity> UserLoginEntities { get; set; }
    public virtual DbSet<RoleClaimEntity> RoleClaimEntities { get; set; }
    public virtual DbSet<UserTokenEntity> UserTokenEntities { get; set; }
    #endregion

    public virtual DbSet<MenuEntity> MenuEntities { get; set; }
    public virtual DbSet<RoleMenuEntity> RoleMenuEntities { get; set; }
}
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