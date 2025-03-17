using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Application.Users.Models;
using CleanArchitectureBlazor.Core.Domain.Users.Entities;

namespace CleanArchitectureBlazor.Core.Application.Users;

public interface IUserRepository : IAggregateRepository<User, long>
{
    Task<UserProfileDTO> GetCurrentUserAsync(CancellationToken cancellation);
}
