using CleanArchitectureBlazor.Core.Domain.BaseCoreDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureBlazor.Core.Domain.Entities.Security;

[Table("UserToken", Schema = "Security"), Description("[Security].[UserTokens]=>توکن کاربر")]
public class UserTokenEntity : IdentityUserToken<long>, IEntity
{

    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid Key { get; set; }
    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }
}
