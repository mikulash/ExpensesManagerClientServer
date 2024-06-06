using System;
using System.Collections.Generic;
using System.Linq;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace ExpensesManager.Server.Tests.Services;

[TestSubject(typeof(UserService))]
public class UserServiceTests
{
    private readonly Mock<IIncomeService> _incomeServiceMock;
    private readonly Mock<IExpenseService> _expenseServiceMock;
    private readonly Mock<ICategoryService> _categoryServiceMock;
    private readonly UserService _userService;
    private const string userId = "testUserId";

    public UserServiceTests()
    {
        _incomeServiceMock = new Mock<IIncomeService>();
        _expenseServiceMock = new Mock<IExpenseService>();
        _categoryServiceMock = new Mock<ICategoryService>();

        // necessary dependencies for user manager
        var store = new Mock<IUserStore<IdentityUser>>();
        var options = new Mock<IOptions<IdentityOptions>>();
        var passwordHasher = new Mock<IPasswordHasher<IdentityUser>>();
        var userValidators = new List<IUserValidator<IdentityUser>> { new Mock<IUserValidator<IdentityUser>>().Object };
        var passwordValidators = new List<IPasswordValidator<IdentityUser>>
            { new Mock<IPasswordValidator<IdentityUser>>().Object };
        var keyNormalizer = new Mock<ILookupNormalizer>();
        var errors = new Mock<IdentityErrorDescriber>();
        var services = new Mock<IServiceProvider>();
        var logger = new Mock<ILogger<UserManager<IdentityUser>>>();

        var userManagerMock = new Mock<UserManager<IdentityUser>>(
            store.Object, options.Object, passwordHasher.Object, userValidators, passwordValidators,
            keyNormalizer.Object, errors.Object, services.Object, logger.Object);

        _userService = new UserService(_incomeServiceMock.Object, _expenseServiceMock.Object,
            _categoryServiceMock.Object, userManagerMock.Object);
    }

    [Fact]
    public void GetCurrentBalance_ShouldReturnCorrectBalance()
    {
        // Arrange
        var incomes = new List<Income>
        {
            new() { Amount = 100 },
            new() { Amount = 200 }
        };
        var expenses = new List<Expense>
        {
            new() { Amount = 50 },
            new() { Amount = 100 }
        };

        _incomeServiceMock.Setup(service => service.GetAllIncomesByUser(userId)).Returns(incomes);
        _expenseServiceMock.Setup(service => service.GetAllExpensesByUser(userId)).Returns(expenses);

        // Act
        var result = _userService.GetCurrentBalance(userId);

        // Assert
        Assert.Equal(150, result);
    }

    [Fact]
    public void GetTotalIncome_ShouldReturnCorrectTotalIncome()
    {
        // Arrange
        var incomes = new List<Income>
        {
            new() { Amount = 100 },
            new() { Amount = 200 }
        };

        _incomeServiceMock.Setup(service => service.GetAllIncomesByUser(userId)).Returns(incomes);

        // Act
        var result = _userService.GetTotalIncome(userId);

        // Assert
        Assert.Equal(300, result);
    }

    [Fact]
    public void GetTotalExpense_ShouldReturnCorrectTotalExpense()
    {
        // Arrange
        var expenses = new List<Expense>
        {
            new() { Amount = 50 },
            new() { Amount = 100 }
        };

        _expenseServiceMock.Setup(service => service.GetAllExpensesByUser(userId)).Returns(expenses);

        // Act
        var result = _userService.GetTotalExpense(userId);

        // Assert
        Assert.Equal(150, result);
    }

    [Fact]
    public void GetStatistics_ShouldReturnCorrectStatistics()
    {
        // Arrange
        var incomes = new List<Income>
        {
            new() { Amount = 100, Date = new DateTime(2022, 5, 1), CategoryId = 1 },
            new() { Amount = 200, Date = new DateTime(2022, 6, 1), CategoryId = 2 }
        };
        var expenses = new List<Expense>
        {
            new() { Amount = 50, Date = new DateTime(2022, 5, 1), CategoryId = 1 },
            new() { Amount = 100, Date = new DateTime(2022, 6, 1), CategoryId = 2 }
        };

        _incomeServiceMock.Setup(service => service.GetAllIncomesByUser(userId)).Returns(incomes);
        _expenseServiceMock.Setup(service => service.GetAllExpensesByUser(userId)).Returns(expenses);

        // Act
        var result = _userService.GetStatistics(userId);

        // Assert
        Assert.Equal(300, result.TotalIncome);
        Assert.Equal(150, result.TotalExpense);
        Assert.Equal(150, result.Balance);

        Assert.Equal(2, result.IncomePerMonth.Count);
        Assert.Equal(2, result.ExpensePerMonth.Count);
        Assert.Equal(2, result.BalancePerMonth.Count);

        Assert.Equal(2, result.IncomePerCategory.Count);
        Assert.Equal(2, result.ExpensePerCategory.Count);
        Assert.Equal(2, result.BalancePerCategory.Count);
    }

    [Fact]
    public void InitNewUser_ShouldInitializeDefaultCategories()
    {
        // Arrange
        _categoryServiceMock.Setup(service => service.SetCategories(It.IsAny<List<Category>>())).Returns(true);

        // Act
        _userService.InitNewUser(userId);

        // Assert
        _categoryServiceMock.Verify(service => service.SetCategories(It.Is<List<Category>>(categories =>
            categories.Count == 3 &&
            categories.Any(c => c.Name == "Food") &&
            categories.Any(c => c.Name == "Utilities") &&
            categories.Any(c => c.Name == "Salary")
        )), Times.Once);
    }
}
