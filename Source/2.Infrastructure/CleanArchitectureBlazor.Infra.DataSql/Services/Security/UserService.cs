using CleanArchitectureBlazor.Core.ApplicationService.Repositories.Security;
using CleanArchitectureBlazor.Core.Domain.Entities.Security;
using CleanArchitectureBlazor.Infra.DataSql.BaseInfraData.Services;
using CleanArchitectureBlazor.Infra.DataSql.Context;

namespace CleanArchitectureBlazor.Infra.DataSql.Services.Security;

public class UserService : BaseService<UserEntity>, IUserService
{
    public UserService(DbContextApplication context) : base(context)
    {
    }
}
