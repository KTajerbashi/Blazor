using CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Services;
using CleanArchitectureBlazor.Core.ApplicationService.Models.Setting.Menu;
using CleanArchitectureBlazor.Core.Domain.Entities.Setting;

namespace CleanArchitectureBlazor.Core.ApplicationService.Repositories.Setting;

public interface IMenuService : IBaseService<MenuEntity>
{
    Task<IEnumerable<MenuProfileModel>> ReadProfileAsync();

}