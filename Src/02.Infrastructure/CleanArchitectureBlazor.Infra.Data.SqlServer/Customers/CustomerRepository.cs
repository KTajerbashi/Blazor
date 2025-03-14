using CleanArchitectureBlazor.Core.Application.Customers;
using CleanArchitectureBlazor.Core.Domain.Customers.Entities;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Common.DataBase;

namespace CleanArchitectureBlazor.Infra.Data.SqlServer.Customers;

public class CustomerRepository : AggregateRepository<DataContext, Customer, long>, ICustomerRepository
{
    public CustomerRepository(DataContext context) : base(context)
    {
    }
}
