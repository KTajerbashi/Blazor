using CleanArchitectureBlazor.Core.Application.Categories;
using CleanArchitectureBlazor.Core.Domain.Categories.Entities;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Categories;

public class CategoryRepository : AggregateRepository<DataContext, Category, long>, ICategoryRepository
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
