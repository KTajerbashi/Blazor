using CleanArchitectureBlazor.Core.CoreBase.Entities;
using CleanArchitectureBlazor.Core.Domains.Privilege;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Security;

[Table("Role", Schema = "Security"), Description("نقش")]
public class RoleEntity : IdentityRole<long>, IEntity
{
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid Key { get; set; }

    public RoleEntity(string name):base(name)
    {
        
    }
    public RoleEntity()
    {
        
    }
    public virtual ICollection<RoleMenuEntity> RoleMenuEntities { get; set; }

}
