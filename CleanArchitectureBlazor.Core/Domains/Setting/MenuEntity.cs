using CleanArchitectureBlazor.Core.CoreBase.Entities;
using CleanArchitectureBlazor.Core.Domains.Privilege;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Setting;

[Table("Menu", Schema = "Setting"), Description("اعتبارات نقش")]
public class MenuEntity : Entity
{
    public byte Order { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }


    [ForeignKey(nameof(Children))]
    public long? ParentId { get; set; }
    public virtual MenuEntity Children { get; set; }

    public virtual ICollection<RoleMenuEntity> RoleMenuEntities { get; set; }

    public MenuEntity()
    {
        Key = Guid.NewGuid();
    }
}
