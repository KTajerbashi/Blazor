using BlazorSolution.Core.Application.Orders;
using BlazorSolution.Core.Domain.Orders.Entities;
using BlazorSolution.Infra.Data.SqlServer.Common;
using BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

namespace BlazorSolution.Infra.Data.SqlServer.Repositories.Orders;

public class OrderRepository : AggregateRepository<DataContext, Order, long>, IOrderRepository
{
    public OrderRepository(DataContext context) : base(context)
    {
    }
}
