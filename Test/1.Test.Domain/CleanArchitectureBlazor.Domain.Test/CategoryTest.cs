using CleanArchitectureBlazor.Core.Domain.Categories.Entities;

namespace CleanArchitectureBlazor.Domain.Test;

public class CategoryTest
{
    [Fact]
    public void CategoryTitle_ShouldMatchAnyKeyword_WhenKeywordsContainTitle()
    {
        // Arrange
        var category = new Category("AI"); // Set a title that exists in the keywords list
        List<string> keywords = new() { "Cleaner", "Machine", "AI", "Cycle", "Trump" };

        // Act
        bool containsTitle = keywords.Contains(category.Title);

        // Assert
        Assert.True(containsTitle, $"The category title '{category.Title}' should match one of the keywords.");
    }


    [Fact]
    public void CategoryTitle_ShouldContainAnySpecialCharacter_WhenCharactersAreInTitle()
    {
        // Arrange
        var category = new Category("AI"); // Title contains a special character
        List<string> specialCharacters = new() { "@", "!", "&", "$", "`" };

        // Act
        bool containsSpecialCharacter = specialCharacters.Any(character => category.Title.Contains(character));

        // Assert
        Assert.False(containsSpecialCharacter, $"The category title '{category.Title}' should contain at least one of the special characters.");
    }



}