using ExpensesManager.Server.Data;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Repositories;

public class ExpenseRepository(ApplicationDbContext context)
{
    public List<Expense> GetAllExpensesByUser(string userId)
    {
        return context.Expenses.Where(e => e.UserId == userId).ToList();
    }

    public Expense? GetExpenseById(int expenseId)
    {
        return context.Expenses.FirstOrDefault(e => e.Id == expenseId);
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
        foreach (var expense in expenses) SetExpense(expense);

        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool DeleteExpense(int expenseId)
    {
        var expense = context.Expenses.FirstOrDefault(e => e.Id == expenseId);
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
        return context.Expenses.Where(e => e.CategoryId == categoryId).ToList();
    }

    public List<Expense> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate)
    {
        return context.Expenses.Where(e => e.Date >= startDate && e.Date <= endDate).ToList();
    }

    public List<Expense> GetExpensesByAmountRange(string userId, decimal startAmount, decimal endAmount)
    {
        return context.Expenses.Where(e => e.Amount >= startAmount && e.Amount <= endAmount).ToList();
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
