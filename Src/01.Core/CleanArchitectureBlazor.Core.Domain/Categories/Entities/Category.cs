using CleanArchitectureBlazor.Core.Domain.Categories.Events;
using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Domain.Categories.Entities;

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
        AddEvent(new CategoryTitleUpdated(Title,Id));
    }


}
