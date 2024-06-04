using System.Collections.Generic;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Repositories;
using ExpensesManager.Server.Services;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace ExpensesManager.Server.Tests.Services;

[TestSubject(typeof(CategoryService))]
public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly CategoryService _categoryService;
    private const string userId = "testUserId";

    public CategoryServiceTests()
    {
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _categoryService = new CategoryService(_categoryRepositoryMock.Object);
    }

    [Fact]
    public void GetAllCategoriesByUser_ShouldReturnCategories()
    {
        // Arrange
        var expectedCategories = new List<Category>
        {
            new() { Name = "Food", UserId = userId },
            new() { Name = "Utilities", UserId = userId }
        };

        _categoryRepositoryMock
            .Setup(repo => repo.GetAllCategoriesByUser(userId, true))
            .Returns(expectedCategories);

        // Act
        var result = _categoryService.GetAllCategoriesByUser(userId);

        // Assert
        Assert.Equal(expectedCategories, result);
    }

    [Fact]
    public void GetCategoryById_ShouldReturnCategory()
    {
        // Arrange
        const int categoryId = 1;
        var expectedCategory = new Category { Id = categoryId, Name = "Food", UserId = userId };

        _categoryRepositoryMock
            .Setup(repo => repo.GetCategoryById(categoryId, userId))
            .Returns(expectedCategory);

        // Act
        var result = _categoryService.GetCategoryById(categoryId, userId);

        // Assert
        Assert.Equal(expectedCategory, result);
    }

    [Fact]
    public void SetCategory_ShouldReturnTrue()
    {
        // Arrange
        var category = new Category { Name = "Food", UserId = userId };

        _categoryRepositoryMock
            .Setup(repo => repo.SetCategory(category))
            .Returns(true);

        // Act
        var result = _categoryService.SetCategory(category);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SetCategories_ShouldReturnTrue()
    {
        // Arrange
        var categories = new List<Category>
        {
            new() { Name = "Food", UserId = userId },
            new() { Name = "Utilities", UserId = userId }
        };

        _categoryRepositoryMock
            .Setup(repo => repo.SetCategories(categories))
            .Returns(true);

        // Act
        var result = _categoryService.SetCategories(categories);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteCategory_ShouldReturnTrue()
    {
        // Arrange
        const int categoryId = 1;

        _categoryRepositoryMock
            .Setup(repo => repo.DeleteCategory(categoryId))
            .Returns(true);

        // Act
        var result = _categoryService.DeleteCategory(categoryId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteAllCategories_ShouldReturnTrue()
    {
        // Arrange
        _categoryRepositoryMock
            .Setup(repo => repo.DeleteAllCategories(userId))
            .Returns(true);

        // Act
        var result = _categoryService.DeleteAllCategories(userId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CreateDefaultCategories_ShouldReturnDefaultCategories()
    {
        // Arrange
        var expectedCategories = new List<Category>
        {
            new() { Name = "Food", UserId = userId },
            new() { Name = "Utilities", UserId = userId },
            new() { Name = "Salary", UserId = userId }
        };

        // Act
        var result = CategoryService.CreateDefaultCategories(userId);

        // Assert
        Assert.Equal(expectedCategories.Count, result.Count);
        for (var i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i].Name, result[i].Name);
            Assert.Equal(expectedCategories[i].UserId, result[i].UserId);
        }
    }
}
