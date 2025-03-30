using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Customers.Entities;

[Table("Customers", Schema = "Business")]
public class Customer : Aggregate
{
}
