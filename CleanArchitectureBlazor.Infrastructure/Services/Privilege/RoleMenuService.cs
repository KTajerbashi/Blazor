using CleanArchitectureBlazor.Application.Repositories.Privilege;
using CleanArchitectureBlazor.Core.Domains.Privilege;
using CleanArchitectureBlazor.Infrastructure.ApplicationContext;
using CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Services;

namespace CleanArchitectureBlazor.Infrastructure.Services.Privilege;

public class RoleMenuService : BaseService<RoleMenuEntity>, IRoleMenuService
{
    public RoleMenuService(DbContextApplication context) : base(context)
    {
    }
}
