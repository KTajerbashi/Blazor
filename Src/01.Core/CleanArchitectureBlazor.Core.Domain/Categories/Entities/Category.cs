using CleanArchitectureBlazor.Core.Domain.Categories.Events;
using CleanArchitectureBlazor.Core.Domain.Common;

namespace CleanArchitectureBlazor.Core.Domain.Categories.Entities;

[Table("Categories", Schema = "Business")]
public class Category : Aggregate
{
    public string Title { get; private set; }

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
