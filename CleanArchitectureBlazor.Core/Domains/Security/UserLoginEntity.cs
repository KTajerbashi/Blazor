using CleanArchitectureBlazor.Core.CoreBase.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Security;

[Table("UserLogin", Schema = "Security"), Description("لاگین های کاربر")]
public class UserLoginEntity : IdentityUserLogin<long>, IEntity {}
