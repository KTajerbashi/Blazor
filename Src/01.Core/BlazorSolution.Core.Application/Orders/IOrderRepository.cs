using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Domain.Orders.Entities;

namespace BlazorSolution.Core.Application.Orders;

public interface IOrderRepository : IAggregateRepository<Order, long>
{
}


