using CleanArchitectureBlazor.Core.Application.Users;
using CleanArchitectureBlazor.Core.Application.Users.Models;
using CleanArchitectureBlazor.Core.Domain.Users.Entities;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Users;

public class UserRepository : AggregateRepository<DataContext, User, long>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }

    public Task<UserProfileDTO> GetCurrentUserAsync(CancellationToken cancellation)
    {
        return Task.FromResult(new UserProfileDTO()
        {
            Id = 1,
            Key = Guid.NewGuid(),
            FirstName = "Kamran",
            LastName = "Tajerbahsi",
            Address = "Los Angles",
            Email = "KamranTajerbasi@gmail.com",
            PhoneNumber = "+1 256 152 1555",
            
        });
    }
}
