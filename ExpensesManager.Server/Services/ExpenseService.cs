using ExpensesManager.Server.Models;
using ExpensesManager.Server.Repositories;

namespace ExpensesManager.Server.Services;

public interface IExpenseService
{
    List<Expense> GetAllExpensesByUser(string userId);
    Expense? GetExpenseById(int expenseId);
    bool SetExpense(Expense expense);
    bool SetExpenses(List<Expense> expenses);
    bool DeleteExpense(int expenseId);
    bool DeleteAllExpenses(string userId);
    List<Expense> GetExpensesByCategory(string userId, int categoryId);
    List<Expense> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate);
    List<Expense> GetExpensesByAmountRange(string userId, decimal minAmount, decimal maxAmount);
    List<Expense> GetExpensesByFilters(string userId, List<int> categoryIds, DateTime? startDate, DateTime? endDate);
}

public class ExpenseService(IExpenseRepository expenseRepository) : IExpenseService
{
    public List<Expense> GetAllExpensesByUser(string userId)
    {
        return expenseRepository.GetAllExpensesByUser(userId);
    }

    public Expense? GetExpenseById(int expenseId)
    {
        return expenseRepository.GetExpenseById(expenseId);
    }

    public bool SetExpense(Expense expense)
    {
        return expenseRepository.SetExpense(expense);
    }

    public bool SetExpenses(List<Expense> expenses)
    {
        return expenseRepository.SetExpenses(expenses);
    }

    public bool DeleteExpense(int expenseId)
    {
        return expenseRepository.DeleteExpense(expenseId);
    }

    public bool DeleteAllExpenses(string userId)
    {
        return expenseRepository.DeleteAllExpenses(userId);
    }

    public List<Expense> GetExpensesByCategory(string userId, int categoryId)
    {
        return expenseRepository.GetExpensesByCategory(userId, categoryId);
    }

    public List<Expense> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate)
    {
        return expenseRepository.GetExpensesByDateRange(userId, startDate, endDate);
    }

    public List<Expense> GetExpensesByAmountRange(string userId, decimal minAmount, decimal maxAmount)
    {
        return expenseRepository.GetExpensesByAmountRange(userId, minAmount, maxAmount);
    }

    public List<Expense> GetExpensesByFilters(string userId, List<int> categoryIds, DateTime? startDate,
        DateTime? endDate)
    {
        return expenseRepository.GetExpensesByFilters(userId, categoryIds, startDate, endDate);
    }
}
