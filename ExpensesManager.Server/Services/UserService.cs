using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Services;

public class UserService(IncomeService incomeService, ExpenseService expenseService)
{
    public decimal GetCurrentBalance(int userId)
    {
        var incomes = incomeService.GetAllIncomesByUser(userId);
        var expenses = expenseService.GetAllExpensesByUser(userId);

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);

        return totalIncome - totalExpense;
    }

    public decimal GetTotalIncome(int userId)
    {
        var incomes = incomeService.GetAllIncomesByUser(userId);
        return incomes.Sum(i => i.Amount);
    }

    public decimal GetTotalExpense(int userId)
    {
        var expenses = expenseService.GetAllExpensesByUser(userId);
        return expenses.Sum(e => e.Amount);
    }

    public User GetUser(int userId)
    {
        return new User();
    }

    // todo statistics
}
