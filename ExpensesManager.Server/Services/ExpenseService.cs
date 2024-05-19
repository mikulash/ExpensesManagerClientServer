using ExpensesManager.Server.Models;
using ExpensesManager.Server.Repositories;

namespace ExpensesManager.Server.Services;

public class ExpenseService(ExpenseRepository expenseRepository)
{
    public List<Expense> GetAllExpensesByUser(int userId)
    {
        return expenseRepository.GetAllExpensesByUser(userId);
    }

    public Expense? GetExpenseById(int expenseId)
    {
        return expenseRepository.GetExpenseById(expenseId);
    }

    public bool SetExpense(int userId,Expense expense)
    {
        return expenseRepository.SetExpense(userId, expense);
    }

    public bool DeleteExpense(int expenseId)
    {
        return expenseRepository.DeleteExpense(expenseId);
    }

    public bool DeleteAllExpenses(int userId)
    {
        return expenseRepository.DeleteAllExpenses(userId);
    }

    public List<Expense> GetExpensesByCategory(int userId,int categoryId)
    {
        return expenseRepository.GetExpensesByCategory(userId, categoryId);
    }

    public List<Expense> GetExpensesByDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        return expenseRepository.GetExpensesByDateRange(userId, startDate, endDate);
    }

    public List<Expense> GetExpensesByAmountRange(int userId, decimal minAmount, decimal maxAmount)
    {
        return expenseRepository.GetExpensesByAmountRange(userId, minAmount, maxAmount);
    }

}
