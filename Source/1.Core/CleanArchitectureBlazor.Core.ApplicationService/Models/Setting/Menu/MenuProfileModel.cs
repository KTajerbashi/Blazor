using CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Models;

namespace CleanArchitectureBlazor.Core.ApplicationService.Models.Setting.Menu;

public class MenuProfileModel : BaseModel
{
    public long? ParentId { get; set; }
    public byte Order { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
}