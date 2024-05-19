using ExpensesManager.Server.Data;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Repositories;

public class ExpenseRepository(ApplicationDbContext context)
{
    public List<Expense> GetAllExpensesByUser(int userId)
    {
        return context.Expenses.Where(e => e.UserId == userId).ToList();
    }

    public Expense? GetExpenseById(int expenseId)
    {
        return context.Expenses.FirstOrDefault(e => e.Id == expenseId);
    }

    public bool SetExpense(int userId, Expense expense)
    {
        // add or update expense
        var isExpensePresent = context.Expenses.Any(e => e.Id == expense.Id);
        if (isExpensePresent)
            context.Expenses.Update(expense);
        else
            context.Expenses.Add(expense);

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

    public bool DeleteAllExpenses(int userId)
    {
        var expenses = context.Expenses.Where(e => e.UserId == userId).ToList();
        context.Expenses.RemoveRange(expenses);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public List<Expense> GetExpensesByCategory(int userId, int categoryId)
    {
        return context.Expenses.Where(e => e.CategoryId == categoryId).ToList();
    }

    public List<Expense> GetExpensesByDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        return context.Expenses.Where(e => e.Date >= startDate && e.Date <= endDate).ToList();
    }

    public List<Expense> GetExpensesByAmountRange(int userId, decimal startAmount, decimal endAmount)
    {
        return context.Expenses.Where(e => e.Amount >= startAmount && e.Amount <= endAmount).ToList();
    }
}