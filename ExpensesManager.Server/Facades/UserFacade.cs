using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public interface IUserFacade
{
    FacadeResponse<UserDto> GetUser(string userId);
    FacadeResponse<decimal> GetCurrentBalance(string userId);
    FacadeResponse<decimal> GetTotalIncome(string userId);
    FacadeResponse<decimal> GetTotalExpense(string userId);

    FacadeResponse<UserTransactionsDto> GetFilteredTransactions(string userId, List<int>? categoryIds,
        DateTime? dateFrom, DateTime? dateTo);

    FacadeResponse<UserTransactionsDto> GetAllTransactions(string userId);
    FacadeResponse<bool> ImportData(UserImportDataDto transactions, string userId);
    FacadeResponse<UserStatisticsDto> GetStatistics(string userId);
    FacadeResponse<bool> DeleteAllTransactions(string userId);
    FacadeResponse<FileStreamResult> GetStatsGraph(string userId);
    FacadeResponse<bool> BackupUserData(string userId);
    FacadeResponse<bool> RestoreUserData(string userId);
}

public class UserFacade(
    IUserService userService,
    IIncomeService incomeService,
    IExpenseService expenseService,
    ICategoryService categoryService)
    : IUserFacade
{
    private const string invalidUserIdMessage = "User ID cannot be 0.";

    public FacadeResponse<UserDto> GetUser(string userId)
    {
        var retval = new FacadeResponse<UserDto>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var user = userService.GetUser(userId);
        if (user == null) return retval.SetNotFound("User not found.");
        return retval.SetOk(user);
    }

    public FacadeResponse<decimal> GetCurrentBalance(string userId)
    {
        var retval = new FacadeResponse<decimal>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var balance = userService.GetCurrentBalance(userId);
        return retval.SetOk(balance);
    }

    public FacadeResponse<decimal> GetTotalIncome(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var totalIncome = userService.GetTotalIncome(userId);
        return retval.SetOk(totalIncome);
    }

    public FacadeResponse<decimal> GetTotalExpense(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var totalExpense = userService.GetTotalExpense(userId);
        return retval.SetOk(totalExpense);
    }

    public FacadeResponse<UserTransactionsDto> GetFilteredTransactions(string userId, List<int>? categoryIds,
        DateTime? dateFrom, DateTime? dateTo)
    {
        var retval = new FacadeResponse<UserTransactionsDto>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);

        var incomes = incomeService.GetIncomesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();
        var expenses = expenseService.GetExpensesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var userTransactions = new UserTransactionsDto
        {
            Incomes = incomesDto,
            Expenses = expensesDto,
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance
        };

        return retval.SetOk(userTransactions);
    }

    public FacadeResponse<UserTransactionsDto> GetAllTransactions(string userId)
    {
        var retval = new FacadeResponse<UserTransactionsDto>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);

        var incomes = incomeService.GetAllIncomesByUser(userId);
        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();
        var expenses = expenseService.GetAllExpensesByUser(userId);
        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var userTransactions = new UserTransactionsDto
        {
            Incomes = incomesDto,
            Expenses = expensesDto,
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance
        };

        return retval.SetOk(userTransactions);
    }

    public FacadeResponse<bool> ImportData(UserImportDataDto transactions, string userId)
    {
        var retval = new FacadeResponse<bool>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);

        var categoryMap = new Dictionary<int, int>();
        foreach (var categoryDto in transactions.Categories)
        {
            //cannot use clients category ids, use them to entity ones
            var category = CategoryMapping.ToCategory(categoryDto, userId);
            var insertionSuccess = categoryService.SetCategory(category);
            if (!insertionSuccess) return retval.SetBadRequest("Error inserting category");
            categoryMap[categoryDto.Id] = category.Id;
        }

        var incomes = transactions.Incomes.Select(i =>
        {
            var income = IncomeMapping.ToIncome(i, userId);
            income.CategoryId = categoryMap[i.CategoryId];
            return income;
        }).ToList();

        var expenses = transactions.Expenses.Select(e =>
        {
            var expense = ExpenseMapping.ToExpense(e, userId);
            expense.CategoryId = categoryMap[e.CategoryId];
            return expense;
        }).ToList();

        var incomeResult = incomeService.SetIncomes(incomes);
        var expenseResult = expenseService.SetExpenses(expenses);

        return retval.SetOk(incomeResult && expenseResult && categoryMap.Count == transactions.Categories.Count);
    }

    public FacadeResponse<UserStatisticsDto> GetStatistics(string userId)
    {
        var retval = new FacadeResponse<UserStatisticsDto>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var userStatistics = userService.GetStatistics(userId);
        return retval.SetOk(userStatistics);
    }

    public FacadeResponse<bool> DeleteAllTransactions(string userId)
    {
        var retval = new FacadeResponse<bool>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var incomeResult = incomeService.DeleteAllIncomes(userId);
        var expenseResult = expenseService.DeleteAllExpenses(userId);
        return retval.SetOk(incomeResult && expenseResult);
    }

    public FacadeResponse<FileStreamResult> GetStatsGraph(string userId)
    {
        var retval = new FacadeResponse<FileStreamResult>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var statsGraph = userService.GetStatsGraph(userId);
        if (statsGraph == null) return retval.SetNotFound("No data to display");
        var file = new FileStreamResult(statsGraph, "image/png");
        return retval.SetOk(file);
    }

    public FacadeResponse<bool> BackupUserData(string userId)
    {
        var retval = new FacadeResponse<bool>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var isSuccess = userService.BackupUserData(userId);
        return isSuccess ? retval.SetOk(true) : retval.SetServerError("Error backing up data");
    }

    public FacadeResponse<bool> RestoreUserData(string userId)
    {
        var retval = new FacadeResponse<bool>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var isSuccess = userService.RestoreUserData(userId);
        return isSuccess ? retval.SetOk(true) : retval.SetServerError("Error restoring data");
    }
}
