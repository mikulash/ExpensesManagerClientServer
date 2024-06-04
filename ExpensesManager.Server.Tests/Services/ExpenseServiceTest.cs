using System;
using System.Collections.Generic;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Repositories;
using ExpensesManager.Server.Services;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace ExpensesManager.Server.Tests.Services;

[TestSubject(typeof(ExpenseService))]
public class ExpenseServiceTests
{
    private readonly Mock<IExpenseRepository> _expenseRepositoryMock;
    private readonly ExpenseService _expenseService;
    private const string userId = "testUserId";

    public ExpenseServiceTests()
    {
        _expenseRepositoryMock = new Mock<IExpenseRepository>();
        _expenseService = new ExpenseService(_expenseRepositoryMock.Object);
    }

    [Fact]
    public void GetAllExpensesByUser_ShouldReturnExpenses()
    {
        // Arrange
        var expectedExpenses = new List<Expense>
        {
            new() { Id = 1, UserId = userId, Amount = 100 },
            new() { Id = 2, UserId = userId, Amount = 200 }
        };

        _expenseRepositoryMock.Setup(repo => repo.GetAllExpensesByUser(userId)).Returns(expectedExpenses);

        // Act
        var result = _expenseService.GetAllExpensesByUser(userId);

        // Assert
        Assert.Equal(expectedExpenses, result);
    }

    [Fact]
    public void GetExpenseById_ShouldReturnExpense()
    {
        // Arrange
        const int expenseId = 1;
        var expectedExpense = new Expense { Id = expenseId, UserId = userId, Amount = 100 };

        _expenseRepositoryMock.Setup(repo => repo.GetExpenseById(expenseId)).Returns(expectedExpense);

        // Act
        var result = _expenseService.GetExpenseById(expenseId);

        // Assert
        Assert.Equal(expectedExpense, result);
    }

    [Fact]
    public void SetExpense_ShouldReturnTrue()
    {
        // Arrange
        var expense = new Expense { Id = 1, UserId = userId, Amount = 100 };

        _expenseRepositoryMock.Setup(repo => repo.SetExpense(expense)).Returns(true);

        // Act
        var result = _expenseService.SetExpense(expense);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SetExpenses_ShouldReturnTrue()
    {
        // Arrange
        var expenses = new List<Expense>
        {
            new() { Id = 1, UserId = userId, Amount = 100 },
            new() { Id = 2, UserId = userId, Amount = 200 }
        };

        _expenseRepositoryMock.Setup(repo => repo.SetExpenses(expenses)).Returns(true);

        // Act
        var result = _expenseService.SetExpenses(expenses);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteExpense_ShouldReturnTrue()
    {
        // Arrange
        const int expenseId = 1;

        _expenseRepositoryMock.Setup(repo => repo.DeleteExpense(expenseId)).Returns(true);

        // Act
        var result = _expenseService.DeleteExpense(expenseId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteAllExpenses_ShouldReturnTrue()
    {
        // Arrange
        _expenseRepositoryMock.Setup(repo => repo.DeleteAllExpenses(userId)).Returns(true);

        // Act
        var result = _expenseService.DeleteAllExpenses(userId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetExpensesByCategory_ShouldReturnExpenses()
    {
        // Arrange
        const int categoryId = 1;
        var expectedExpenses = new List<Expense>
        {
            new() { Id = 1, UserId = userId, CategoryId = categoryId, Amount = 100 },
            new() { Id = 2, UserId = userId, CategoryId = categoryId, Amount = 200 }
        };

        _expenseRepositoryMock.Setup(repo => repo.GetExpensesByCategory(userId, categoryId)).Returns(expectedExpenses);

        // Act
        var result = _expenseService.GetExpensesByCategory(userId, categoryId);

        // Assert
        Assert.Equal(expectedExpenses, result);
    }

    [Fact]
    public void GetExpensesByDateRange_ShouldReturnExpenses()
    {
        // Arrange
        var startDate = new DateTime(2022, 1, 1);
        var endDate = new DateTime(2022, 12, 31);
        var expectedExpenses = new List<Expense>
        {
            new() { Id = 1, UserId = userId, Date = new DateTime(2022, 5, 1), Amount = 100 },
            new() { Id = 2, UserId = userId, Date = new DateTime(2022, 6, 1), Amount = 200 }
        };

        _expenseRepositoryMock.Setup(repo => repo.GetExpensesByDateRange(userId, startDate, endDate))
            .Returns(expectedExpenses);

        // Act
        var result = _expenseService.GetExpensesByDateRange(userId, startDate, endDate);

        // Assert
        Assert.Equal(expectedExpenses, result);
    }

    [Fact]
    public void GetExpensesByAmountRange_ShouldReturnExpenses()
    {
        // Arrange
        const int minAmount = 100;
        const int maxAmount = 200;
        var expectedExpenses = new List<Expense>
        {
            new() { Id = 1, UserId = userId, Amount = 100 },
            new() { Id = 2, UserId = userId, Amount = 150 }
        };

        _expenseRepositoryMock.Setup(repo => repo.GetExpensesByAmountRange(userId, minAmount, maxAmount))
            .Returns(expectedExpenses);

        // Act
        var result = _expenseService.GetExpensesByAmountRange(userId, minAmount, maxAmount);

        // Assert
        Assert.Equal(expectedExpenses, result);
    }

    [Fact]
    public void GetExpensesByFilters_ShouldReturnExpenses()
    {
        // Arrange
        var categoryIds = new List<int> { 1, 2 };
        var startDate = new DateTime(2022, 1, 1);
        var endDate = new DateTime(2022, 12, 31);
        var expectedExpenses = new List<Expense>
        {
            new() { Id = 1, UserId = userId, CategoryId = 1, Date = new DateTime(2022, 5, 1), Amount = 100 },
            new() { Id = 2, UserId = userId, CategoryId = 2, Date = new DateTime(2022, 6, 1), Amount = 200 }
        };

        _expenseRepositoryMock.Setup(repo => repo.GetExpensesByFilters(userId, categoryIds, startDate, endDate))
            .Returns(expectedExpenses);

        // Act
        var result = _expenseService.GetExpensesByFilters(userId, categoryIds, startDate, endDate);

        // Assert
        Assert.Equal(expectedExpenses, result);
    }
}
