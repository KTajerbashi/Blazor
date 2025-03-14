using CleanArchitectureBlazor.Core.Application.Orders;
using CleanArchitectureBlazor.Core.Domain.Orders.Entities;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Orders;

public class OrderRepository : AggregateRepository<DataContext, Order, long>, IOrderRepository
{
    public OrderRepository(DataContext context) : base(context)
    {
    }
}
