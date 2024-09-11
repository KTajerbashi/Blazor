using CleanArchitectureBlazor.Application.ApplicationBase.Services;
using CleanArchitectureBlazor.Application.Models.Setting.Menu;
using CleanArchitectureBlazor.Core.Domains.Setting;

namespace CleanArchitectureBlazor.Application.Repositories.Setting;

public interface IMenuService : IBaseService<MenuEntity>
{
    Task<IEnumerable<MenuProfileModel>> ReadProfileAsync(); 

}
