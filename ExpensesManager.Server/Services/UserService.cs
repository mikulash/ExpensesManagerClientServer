using ExpensesManager.Server.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ExpensesManager.Server.Services;

public interface IUserService
{
    decimal GetCurrentBalance(string userId);
    decimal GetTotalIncome(string userId);
    decimal GetTotalExpense(string userId);
    UserStatisticsDto GetStatistics(string userId);
    void InitNewUser(string userId);
    UserDto? GetUser(string userId);
}

public class UserService(
    IIncomeService incomeService,
    IExpenseService expenseService,
    ICategoryService categoryService,
    UserManager<IdentityUser> userManager)
    : IUserService
{
    public UserDto? GetUser(string userId)
    {
        var user = userManager.FindByIdAsync(userId).Result;
        if (user == null) return null;

        return new UserDto
        {
            UserId = userId,
            Username = user.UserName,
            Email = user.Email
        };
    }

    public decimal GetCurrentBalance(string userId)
    {
        var incomes = incomeService.GetAllIncomesByUser(userId);
        var expenses = expenseService.GetAllExpensesByUser(userId);

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);

        return totalIncome - totalExpense;
    }

    public decimal GetTotalIncome(string userId)
    {
        var incomes = incomeService.GetAllIncomesByUser(userId);
        return incomes.Sum(i => i.Amount);
    }

    public decimal GetTotalExpense(string userId)
    {
        var expenses = expenseService.GetAllExpensesByUser(userId);
        return expenses.Sum(e => e.Amount);
    }

    public UserStatisticsDto GetStatistics(string userId)
    {
        var incomes = incomeService.GetAllIncomesByUser(userId);
        var expenses = expenseService.GetAllExpensesByUser(userId);

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var incomePerMonth = incomes.GroupBy(i => i.Date.Month)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(i => i.Amount) }).ToList();

        var expensePerMonth = expenses.GroupBy(e => e.Date.Month)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(e => e.Amount) }).ToList();

        var balancePerMonth = incomePerMonth.Select(i => new { i.Key, i.Total })
            .Join(expensePerMonth, i => i.Key, e => e.Key,
                (i, e) => new AggregatedTotalDto { Key = i.Key, Total = i.Total - e.Total }).ToList();

        var incomesPerCategory = incomes.GroupBy(i => i.CategoryId)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(i => i.Amount) }).ToList();

        var expensesPerCategory = expenses.GroupBy(e => e.CategoryId)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(e => e.Amount) }).ToList();

        var balancePerCategory = incomesPerCategory.Select(i => new { i.Key, i.Total })
            .Join(expensesPerCategory, i => i.Key, e => e.Key,
                (i, e) => new AggregatedTotalDto { Key = i.Key, Total = i.Total - e.Total }).ToList();

        var userStatistics = new UserStatisticsDto
        {
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance,
            IncomePerMonth = incomePerMonth,
            ExpensePerMonth = expensePerMonth,
            BalancePerMonth = balancePerMonth,
            IncomePerCategory = incomesPerCategory,
            ExpensePerCategory = expensesPerCategory,
            BalancePerCategory = balancePerCategory
        };

        return userStatistics;
    }

    public void InitNewUser(string userId)
    {
        var categories = CategoryService.CreateDefaultCategories(userId);
        categoryService.SetCategories(categories);
    }
}
