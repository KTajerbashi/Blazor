using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Application.Products;
using CleanArchitectureBlazor.Core.Domain.Products.Entities;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Products;
public class ProductRepository : AggregateRepository<DataContext, Product, long>, IProductRepository
{
    private readonly IEventStore _eventStore;
    public ProductRepository(DataContext context, IEventStore eventStore) : base(context)
    {
        _eventStore = eventStore;
    }

    public override void Save(Product aggregate)
    {
        var events = aggregate.Events;
        string typeName = typeof(Product).Name;
        _eventStore.Save(typeName, aggregate.Id, aggregate.Version, events.ToList());
    }
    public override Product Get(long id)
    {
        string typeName = typeof(Product).Name;
        var events = _eventStore.Get(typeName,id);
        return new Product(events);
    }
}
