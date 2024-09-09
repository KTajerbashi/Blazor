using CleanArchitectureBlazor.Core.CoreBase.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Security;

[Table("UserToken", Schema = "Security"), Description("[Security].[UserTokens]=>توکن کاربر")]
public class UserTokenEntity : IdentityUserToken<long>, IEntity { }
