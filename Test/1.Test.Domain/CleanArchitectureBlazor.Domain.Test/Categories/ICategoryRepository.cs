using CleanArchitectureBlazor.Core.Domain.Categories.Entities;
using CleanArchitectureBlazor.Domain.Test.Exceptions;

namespace CleanArchitectureBlazor.Domain.Test.Categories;

public interface ICategoryRepository
{
    void Add(Category category);
    Category GetById(string key);
    void Update(Category category);
    void Delete(string key);
}

public class CategoryRepository : ICategoryRepository
{
    private List<Category> DataList;
    public CategoryRepository()
    {
        DataList = new();
        DataList.Add(new Category("HTML"));
        DataList.Add(new Category("CSS"));
        DataList.Add(new Category("JS"));
        DataList.Add(new Category("TS"));
        DataList.Add(new Category("C#"));
        DataList.Add(new Category("T-SQL"));
        DataList.Add(new Category("Python"));
        DataList.Add(new Category("React"));
        DataList.Add(new Category("AngularJs"));
        DataList.Add(new Category("Angular"));
    }

    public void Add(Category category)
    {
        if (DataList.Any(item => item.Title.ToLower() == category.Title.ToLower()))
            throw new DataExistException("Category already exists.");

        DataList.Add(category);
    }

    public void Delete(string key) => DataList.Remove(DataList.FirstOrDefault(x => x.Title == key));

    public Category GetById(string key) => DataList.FirstOrDefault(x => x.Title == key);

    public void Update(Category category)
    {
        var entity = DataList.FirstOrDefault(x => x.Title == category.Title);
        if (entity is null)
            return;
        entity.UpdateTitle(category.Title);
    }
}