using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Orders.Entities;

[Table("Orders", Schema = "Business")]
public class Order : Aggregate
{
}
