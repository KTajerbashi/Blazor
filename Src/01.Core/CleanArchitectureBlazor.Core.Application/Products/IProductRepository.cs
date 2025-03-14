using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Domain.Products.Entities;

namespace CleanArchitectureBlazor.Core.Application.Products;

public interface IProductRepository : IAggregateRepository<Product, long>
{
}


