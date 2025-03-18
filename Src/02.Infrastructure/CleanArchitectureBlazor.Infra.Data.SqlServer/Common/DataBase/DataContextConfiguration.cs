using CleanArchitectureBlazor.Infra.Data.SqlServer.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

public static class DataContextConfiguration
{
    public static ModelBuilder AddSecurityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable("Users", "Security");
        builder.Entity<ApplicationUserClaim>().ToTable("UserClaims", "Security");
        builder.Entity<ApplicationUserLogin>().ToTable("UserLogins", "Security");
        builder.Entity<ApplicationUserRole>().ToTable("UserRoles", "Security");
        builder.Entity<ApplicationUserToken>().ToTable("UserTokens", "Security");
        builder.Entity<ApplicationRole>().ToTable("Roles", "Security");
        builder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims", "Security");
        return builder;
    }
}
