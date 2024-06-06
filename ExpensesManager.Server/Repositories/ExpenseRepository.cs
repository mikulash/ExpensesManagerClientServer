using ExpensesManager.Server.Data;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Repositories;

public interface IExpenseRepository
{
    List<Expense> GetAllExpensesByUser(string userId);
    Expense? GetExpenseById(int expenseId, string userId);
    bool SetExpense(Expense expense);
    bool SetExpenses(List<Expense> expenses);
    bool DeleteExpense(int expenseId, string userId);
    bool DeleteAllExpenses(string userId);
    List<Expense> GetExpensesByCategory(string userId, int categoryId);
    List<Expense> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate);
    List<Expense> GetExpensesByAmountRange(string userId, decimal startAmount, decimal endAmount);
    List<Expense> GetExpensesByFilters(string userId, List<int> categoryIds, DateTime? startDate, DateTime? endDate);
}

public class ExpenseRepository(ApplicationDbContext context) : IExpenseRepository
{
    public List<Expense> GetAllExpensesByUser(string userId)
    {
        return context.Expenses.Where(e => e.UserId == userId).ToList();
    }

    public Expense? GetExpenseById(int expenseId, string userId)
    {
        return context.Expenses.FirstOrDefault(e => e.Id == expenseId && e.UserId == userId);
    }

    /**
     * Add or update expense
     * @param expense object
     * @return bool True if changes saved successfully, false otherwise
     */
    public bool SetExpense(Expense expense)
    {
        var isExpensePresent = context.Expenses.Any(e => e.Id == expense.Id);
        if (isExpensePresent)
            context.Expenses.Update(expense);
        else
            context.Expenses.Add(expense);

        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool SetExpenses(List<Expense> expenses)
    {
        foreach (var expense in expenses)
        {
            var isStoredSuccessfully = SetExpense(expense);
            if (!isStoredSuccessfully) return false;
        }

        return true;
    }

    public bool DeleteExpense(int expenseId, string userId)
    {
        var expense = context.Expenses.FirstOrDefault(e => e.Id == expenseId && e.UserId == userId);
        if (expense == null) return false;

        context.Expenses.Remove(expense);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool DeleteAllExpenses(string userId)
    {
        var expenses = context.Expenses.Where(e => e.UserId == userId).ToList();
        context.Expenses.RemoveRange(expenses);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public List<Expense> GetExpensesByCategory(string userId, int categoryId)
    {
        return context.Expenses.Where(e => e.CategoryId == categoryId && e.UserId == userId).ToList();
    }

    public List<Expense> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate)
    {
        return context.Expenses.Where(e => e.Date >= startDate && e.Date <= endDate && e.UserId == userId).ToList();
    }

    public List<Expense> GetExpensesByAmountRange(string userId, decimal startAmount, decimal endAmount)
    {
        return context.Expenses.Where(e => e.Amount >= startAmount && e.Amount <= endAmount && e.UserId == userId)
            .ToList();
    }

    public List<Expense> GetExpensesByFilters(string userId, List<int> categoryIds, DateTime? startDate,
        DateTime? endDate)
    {
        var expenses = context.Expenses.Where(e => e.UserId == userId).ToList();
        if (categoryIds.Count > 0)
            expenses = expenses.Where(e => categoryIds.Contains(e.CategoryId)).ToList();
        if (startDate != null)
            expenses = expenses.Where(e => e.Date >= startDate).ToList();
        if (endDate != null)
            expenses = expenses.Where(e => e.Date <= endDate).ToList();

        return expenses;
    }
}
