using CleanArchitectureBlazor.Core.CoreBase.Entities;
using CleanArchitectureBlazor.Core.Domains.Security;
using CleanArchitectureBlazor.Core.Domains.Setting;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Privilege;

[Table("RoleMenu", Schema = "Privilege"), Description("دسترسی منو بر اساس نقش")]
public class RoleMenuEntity : Entity 
{
    [ForeignKey(nameof(Menu))]
    public long MenuId { get; set; }
    public virtual MenuEntity Menu { get; set; }

    [ForeignKey(nameof(Role))]
    public long RoleId { get; set; }
    public virtual RoleEntity Role { get; set; }
}
