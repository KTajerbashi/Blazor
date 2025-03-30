using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Domain.Categories.Entities;

namespace BlazorSolution.Core.Application.Categories;

public interface ICategoryRepository : IAggregateRepository<Category, long>
{
}
