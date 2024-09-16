using CleanArchitectureBlazor.Core.ApplicationService.Repositories.Privilege;
using CleanArchitectureBlazor.Core.Domain.Entities.Privilege;
using CleanArchitectureBlazor.Infra.DataSql.BaseInfraData.Services;
using CleanArchitectureBlazor.Infra.DataSql.Context;

namespace CleanArchitectureBlazor.Infra.DataSql.Services.Privilege;

public class RoleMenuService : BaseService<RoleMenuEntity>, IRoleMenuService
{
    public RoleMenuService(DbContextApplication context) : base(context)
    {
    }
}
