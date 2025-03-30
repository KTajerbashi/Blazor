using BlazorSolution.Core.Domain.Common;

namespace BlazorSolution.Core.Domain.Categories.Events;

public class CategoryCreated : IDomainEvent
{
    public string Title { get; }

    public CategoryCreated(string title)
    {
        Title = title;
    }
}
public class CategoryTitleUpdated : IDomainEvent
{
    public string Title { get; }
    public long Id { get; set; }
    public CategoryTitleUpdated(string title, long id)
    {
        Title = title;
        Id = id;
    }
}
