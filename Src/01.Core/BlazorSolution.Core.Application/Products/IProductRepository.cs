using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Domain.Products.Entities;

namespace BlazorSolution.Core.Application.Products;

public interface IProductRepository : IAggregateRepository<Product, long>
{
}


