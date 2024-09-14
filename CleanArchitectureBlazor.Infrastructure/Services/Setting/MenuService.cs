using CleanArchitectureBlazor.Application.Models.Setting.Menu;
using CleanArchitectureBlazor.Application.Repositories.Setting;
using CleanArchitectureBlazor.Core.Domains.Setting;
using CleanArchitectureBlazor.Infrastructure.ApplicationContext;
using CleanArchitectureBlazor.Infrastructure.InfrastructureBase.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBlazor.Infrastructure.Services.Setting;

public class MenuService : BaseService<MenuEntity>, IMenuService
{
    public MenuService(DbContextApplication context) : base(context)
    {
    }

    public async Task<IEnumerable<MenuProfileModel>> ReadProfileAsync()
    {
        var result= await Context.Set<MenuEntity>()
            .Where(item => !item.IsDeleted && item.IsActive)
            .OrderBy(item => item.Order)
            .Select(item => new MenuProfileModel
            {
                Description = item.Description,
                Icon = item.Icon,
                Id = item.Id,
                Key = item.Key,
                Link = item.Link,
                Order = item.Order,
                ParentId = item.ParentId,
                Title = item.Title
            })
            .ToListAsync();
        return result.ToList();
    }
}
