using CleanArchitectureBlazor.Core.Domain.Categories.Entities;
using CleanArchitectureBlazor.Domain.Test.Exceptions;
using Moq;

namespace CleanArchitectureBlazor.Domain.Test.Categories;

public class CategoryCrudTests
{
    [Fact]
    public void AddCategory_ShouldCallRepositoryAdd()
    {
        // Arrange
        var mockRepository = new Mock<ICategoryRepository>();
        var category = new Category("C++");

        // Act
        mockRepository.Object.Add(category);

        // Assert
        mockRepository.Verify(repo => repo.Add(category), Times.Once);
    }

    [Fact]
    public void AddCategory_ShouldThrowDataExistException_WhenCategoryAlreadyExists()
    {
        // Arrange
        var mockRepository = new Mock<ICategoryRepository>();
        var category = new Category("C++");

        // Simulate the repository throwing an exception when adding a duplicate category
        mockRepository.Setup(repo => repo.Add(category))
            .Throws(new DataExistException("Category already exists."));

        // Act & Assert
        var exception = Assert.Throws<DataExistException>(() => mockRepository.Object.Add(category));
        Assert.Equal("Category already exists.", exception.Message);
    }


    [Fact]
    public void GetCategoryById_ShouldReturnCategory()
    {
        // Arrange
        var mockRepository = new Mock<ICategoryRepository>();
        var category = new Category("Laptop");
        mockRepository.Setup(repo => repo.GetById(category.KeyUniq)).Returns(category);

        // Act
        var result = mockRepository.Object.GetById(category.KeyUniq);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(category.KeyUniq, result.KeyUniq);
        Assert.Equal(category.Title, result.Title);
    }

    [Fact]
    public void UpdateCategory_ShouldCallRepositoryUpdate()
    {
        // Arrange
        var mockRepository = new Mock<ICategoryRepository>();
        var category = new Category("Laptop");

        // Act
        mockRepository.Object.Update(category);

        // Assert
        mockRepository.Verify(repo => repo.Update(category), Times.Once);
    }

    [Fact]
    public void DeleteCategory_ShouldCallRepositoryDelete()
    {
        // Arrange
        var mockRepository = new Mock<ICategoryRepository>();
        var category = new Category("Laptop");

        // Act
        mockRepository.Object.Delete(category.KeyUniq);

        // Assert
        mockRepository.Verify(repo => repo.Delete(category.KeyUniq), Times.Once);
    }

    [Fact]
    public void SetKey_ShouldUpdateKey_WhenValidValueIsProvided()
    {
        // Arrange
        var category = new Category("Laptop");
        var newKey = Guid.NewGuid().ToString();

        // Act
        category.SetKey(newKey);

        // Assert
        Assert.Equal(newKey, category.KeyUniq);
    }

    [Fact]
    public void SetKey_ShouldThrowException_WhenNullValueIsProvided()
    {
        // Arrange
        var category = new Category("Laptop");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => category.SetKey(null));
        Assert.Equal("Key cannot be null or empty.", exception.Message);
    }
}

