using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Domain.Customers.Entities;

[Table("Customers", Schema ="Business")]
public class Customer : Aggregate
{
}
