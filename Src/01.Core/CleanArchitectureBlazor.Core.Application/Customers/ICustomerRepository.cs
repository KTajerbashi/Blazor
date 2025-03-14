using CleanArchitectureBlazor.Core.Application.Common;
using CleanArchitectureBlazor.Core.Domain.Customers.Entities;

namespace CleanArchitectureBlazor.Core.Application.Customers;

public interface ICustomerRepository : IAggregateRepository<Customer, long>
{
}


