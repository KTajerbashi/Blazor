using CleanArchitectureBlazor.Core.Application.Products;
using CleanArchitectureBlazor.Core.Domain.Products.Entities;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Products;

public class ProductRepository : AggregateRepository<DataContext, Product, long>, IProductRepository
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}
