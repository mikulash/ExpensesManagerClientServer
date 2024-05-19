using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Mappings;

public class ExpenseMapping
{
    public static ExpenseDto ToExpenseDto(Expense expense)
    {
        return new ExpenseDto
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Description = expense.Description,
            Date = expense.Date,
            UserId = expense.UserId,
            CategoryId = expense.CategoryId
        };
    }

    public static Expense ToExpense(ExpenseDto expenseDto)
    {
        return new Expense
        {
            Id = expenseDto.Id,
            Amount = expenseDto.Amount,
            Description = expenseDto.Description,
            Date = expenseDto.Date,
            UserId = expenseDto.UserId,
            CategoryId = expenseDto.CategoryId
        };
    }
}
