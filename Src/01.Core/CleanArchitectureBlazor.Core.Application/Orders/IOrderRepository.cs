using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Domain.Orders.Entities;

namespace CleanArchitectureBlazor.Core.Application.Orders;

public interface IOrderRepository : IAggregateRepository<Order, long>
{
}


