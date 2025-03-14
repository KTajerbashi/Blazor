using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Domain.Orders.Entities;

[Table("Orders", Schema = "Business")]
public class Order : Aggregate
{
}
