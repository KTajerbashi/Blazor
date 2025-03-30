using BlazorSolution.Core.Application.Users;
using BlazorSolution.Core.Application.Users.Models;
using BlazorSolution.Core.Domain.Users.Entities;
using BlazorSolution.Infra.Data.SqlServer.Common;
using BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

namespace BlazorSolution.Infra.Data.SqlServer.Users;

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
