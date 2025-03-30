using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Application.Products;
using BlazorSolution.Core.Domain.Products.Entities;
using BlazorSolution.Infra.Data.SqlServer.Common;
using BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

namespace BlazorSolution.Infra.Data.SqlServer.Products;
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
