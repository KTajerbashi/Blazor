using CleanArchitectureBlazor.Core.Domain.BaseCoreDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using CleanArchitectureBlazor.Core.Domain.Entities.Privilege;

namespace CleanArchitectureBlazor.Core.Domain.Entities.Security;

[Table("Role", Schema = "Security"), Description("نقش")]
public class RoleEntity : IdentityRole<long>, IEntity
{
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid Key { get; set; }

    public RoleEntity(string name) : base(name)
    {

    }
    public RoleEntity()
    {

    }
    public virtual ICollection<RoleMenuEntity> RoleMenuEntities { get; set; }
    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }
}

