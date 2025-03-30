using BlazorSolution.Core.Domain.Common;
using BlazorSolution.Core.Domain.Categories.Events;

namespace BlazorSolution.Core.Domain.Categories.Entities;

[Table("Categories", Schema = "Business")]
public class Category : Aggregate
{
    public string Title { get; private set; }
    public string KeyUniq { get; private set; }
    public void SetKey(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Key cannot be null or empty.");
        if (value == KeyUniq) return;
        KeyUniq = value;
    }
    public Category(string title)
    {
        Title = title;
        AddEvent(new CategoryCreated(title));
    }

    public void UpdateTitle(string title)
    {
        Title = title;
        AddEvent(new CategoryTitleUpdated(Title, Id));
    }


}
