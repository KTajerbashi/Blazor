using BlazorSolution.Core.Application.Customers;
using BlazorSolution.Core.Domain.Customers.Entities;
using BlazorSolution.Infra.Data.SqlServer.Common;
using BlazorSolution.Infra.Data.SqlServer.Common.DataBase;

namespace BlazorSolution.Infra.Data.SqlServer.Customers;

public class CustomerRepository : AggregateRepository<DataContext, Customer, long>, ICustomerRepository
{
    public CustomerRepository(DataContext context) : base(context)
    {
    }
}
