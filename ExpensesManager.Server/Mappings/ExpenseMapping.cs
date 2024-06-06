using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Mappings;

public static class ExpenseMapping
{
    public static ExpenseDto ToExpenseDto(Expense expense)
    {
        return new ExpenseDto
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Description = expense.Description,
            Date = expense.Date,
            CategoryId = expense.CategoryId
        };
    }

    public static Expense ToExpense(ExpenseDto expenseDto, string userId)
    {
        return new Expense
        {
            Id = expenseDto.Id,
            Amount = expenseDto.Amount,
            Description = expenseDto.Description,
            Date = expenseDto.Date,
            UserId = userId,
            CategoryId = expenseDto.CategoryId
        };
    }
}
