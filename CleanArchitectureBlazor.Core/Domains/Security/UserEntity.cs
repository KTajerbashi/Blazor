using CleanArchitectureBlazor.Core.CoreBase.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Security;

[Table("User", Schema = "Security"), Description("کاربران")]
public class UserEntity : IdentityUser<long>, IEntity { }
