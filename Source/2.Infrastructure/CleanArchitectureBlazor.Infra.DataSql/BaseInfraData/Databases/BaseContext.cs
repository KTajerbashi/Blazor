using CleanArchitectureBlazor.Core.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infra.DataSql.BaseInfraData.Databases;

public abstract class BaseContext : IdentityDbContext<UserEntity, RoleEntity, long, UserClaimEntity, UserRoleEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>
{
    public BaseContext(DbContextOptions options) : base(options) { }
    protected BaseContext() { }
}
