using ExpensesManager.Server.DTOs;

namespace ExpensesManager.Server.Services;

public class UserService(IncomeService incomeService, ExpenseService expenseService)
{
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

    public UserDto GetUser(string userId)
    {
        return new UserDto();
    }

    // todo statistics
}
