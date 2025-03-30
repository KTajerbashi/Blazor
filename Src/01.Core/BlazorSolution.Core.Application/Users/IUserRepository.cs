using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Application.Users.Models;
using BlazorSolution.Core.Domain.Users.Entities;

namespace BlazorSolution.Core.Application.Users;

public interface IUserRepository : IAggregateRepository<User, long>
{
    Task<UserProfileDTO> GetCurrentUserAsync(CancellationToken cancellation);
}
