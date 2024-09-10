using CleanArchitectureBlazor.Core.Domains.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Databases;

public abstract class BaseContext : IdentityDbContext<UserEntity, RoleEntity, long, UserClaimEntity, UserRoleEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>
{
    public BaseContext(DbContextOptions options) : base(options) { }
    protected BaseContext() { }
}
