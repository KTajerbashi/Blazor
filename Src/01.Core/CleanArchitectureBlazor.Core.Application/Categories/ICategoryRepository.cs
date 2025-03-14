using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Domain.Categories.Entities;

namespace CleanArchitectureBlazor.Core.Application.Categories;

public interface ICategoryRepository : IAggregateRepository<Category, long>
{
}


