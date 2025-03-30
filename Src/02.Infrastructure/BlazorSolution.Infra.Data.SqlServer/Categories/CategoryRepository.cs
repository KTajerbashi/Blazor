using BlazorSolution.Core.Application.Categories;
using BlazorSolution.Core.Domain.Categories.Entities;
using BlazorSolution.Infra.Data.SqlServer.Common;
using BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

namespace BlazorSolution.Infra.Data.SqlServer.Categories;

public class CategoryRepository : AggregateRepository<DataContext, Category, long>, ICategoryRepository
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
