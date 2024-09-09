using CleanArchitectureBlazor.Core.CoreBase.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Security;

[Table("RoleClaim", Schema = "Security"), Description("اعتبارات نقش")]
public class RoleClaimEntity : IdentityRoleClaim<long>, IEntity {}
