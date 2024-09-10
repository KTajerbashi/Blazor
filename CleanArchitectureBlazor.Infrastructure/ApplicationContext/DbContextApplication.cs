using CleanArchitectureBlazor.Core.Domains.Privilege;
using CleanArchitectureBlazor.Core.Domains.Security;
using CleanArchitectureBlazor.Core.Domains.Setting;
using CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Databases;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infrastructure.ApplicationContext;

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
