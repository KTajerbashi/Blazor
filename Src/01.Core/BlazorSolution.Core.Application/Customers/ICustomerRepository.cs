using BlazorSolution.Core.Application.Common;
using BlazorSolution.Core.Domain.Customers.Entities;

namespace BlazorSolution.Core.Application.Customers;

public interface ICustomerRepository : IAggregateRepository<Customer, long>
{
}


