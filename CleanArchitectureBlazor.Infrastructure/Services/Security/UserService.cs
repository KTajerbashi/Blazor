using CleanArchitectureBlazor.Application.Repositories.Security;
using CleanArchitectureBlazor.Core.Domains.Security;
using CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Services;

namespace CleanArchitectureBlazor.Infrastructure.Services.Security;

public class UserService : BaseService<UserEntity>, IUserService
{
}
