using CleanArchitectureBlazor.Core.Domain.BaseCoreDomain;
using CleanArchitectureBlazor.Core.Domain.Entities.Security;
using CleanArchitectureBlazor.Core.Domain.Entities.Setting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domain.Entities.Privilege;

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

