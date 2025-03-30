using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Products.Entities;

[Table("Discounts", Schema = "Business")]
public class Discount : Entity<long>
{
    public string Title { get; private set; }
    public int Value { get; private set; }

    public Discount(string title, int value)
    {
        Title = title;
        Value = value;
    }

}
