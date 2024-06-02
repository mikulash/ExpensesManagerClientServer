using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public class UserFacade(UserService userService, IncomeService incomeService, ExpenseService expenseService)
{
    public FacadeResponse<decimal> GetCurrentBalance(string userId)
    {
        var retval = new FacadeResponse<decimal>();
        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var balance = userService.GetCurrentBalance(userId);
        return retval.SetOk(balance);
    }

    public FacadeResponse<decimal> GetTotalIncome(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var totalIncome = userService.GetTotalIncome(userId);
        return retval.SetOk(totalIncome);
    }

    public FacadeResponse<decimal> GetTotalExpense(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var totalExpense = userService.GetTotalExpense(userId);
        return retval.SetOk(totalExpense);
    }

    public FacadeResponse<UserDto> GetUser(string userId)
    {
        var retval = new FacadeResponse<UserDto>();
        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var user = userService.GetUser(userId);
        return retval.SetOk(user);
    }

    public FacadeResponse<UserTransactionsDto> GetFilteredTransactions(string userId, List<int>? categoryIds,
        DateTime? dateFrom, DateTime? dateTo)
    {
        var retval = new FacadeResponse<UserTransactionsDto>();
        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");

        var incomes = incomeService.GetIncomesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();
        var expenses = expenseService.GetExpensesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var userTransactions = new UserTransactionsDto
        {
            UserId = userId,
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

        var incomes = incomeService.GetAllIncomesByUser(userId);
        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();
        var expenses = expenseService.GetAllExpensesByUser(userId);
        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var userTransactions = new UserTransactionsDto
        {
            UserId = userId,
            Incomes = incomesDto,
            Expenses = expensesDto,
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance
        };

        return retval.SetOk(userTransactions);
    }

    public FacadeResponse<bool> ImportData(UserTransactionsDto transactions)
    {
        var retval = new FacadeResponse<bool>();

        var incomes = transactions.Incomes.Select(IncomeMapping.ToIncome).ToList();
        var expenses = transactions.Expenses.Select(ExpenseMapping.ToExpense).ToList();

        var incomeResult = incomeService.SetIncomes(incomes);
        var expenseResult = expenseService.SetExpenses(expenses);

        return retval.SetOk(incomeResult && expenseResult);
    }

    public FacadeResponse<UserStatisticsDto> GetStatistics(string userId)
    {
        var retval = new FacadeResponse<UserStatisticsDto>();
        var incomes = incomeService.GetAllIncomesByUser(userId);
        var expenses = expenseService.GetAllExpensesByUser(userId);

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var incomePerMonth = incomes.GroupBy(i => i.Date.Month)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(i => i.Amount) }).ToList();

        var expensePerMonth = expenses.GroupBy(e => e.Date.Month)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(e => e.Amount) }).ToList();

        var balancePerMonth = incomePerMonth.Select(i => new { i.Key, i.Total })
            .Join(expensePerMonth, i => i.Key, e => e.Key,
                (i, e) => new AggregatedTotalDto { Key = i.Key, Total = i.Total - e.Total }).ToList();

        var incomesPerCategory = incomes.GroupBy(i => i.CategoryId)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(i => i.Amount) }).ToList();

        var expensesPerCategory = expenses.GroupBy(e => e.CategoryId)
            .Select(g => new AggregatedTotalDto { Key = g.Key, Total = g.Sum(e => e.Amount) }).ToList();

        var balancePerCategory = incomesPerCategory.Select(i => new { i.Key, i.Total })
            .Join(expensesPerCategory, i => i.Key, e => e.Key,
                (i, e) => new AggregatedTotalDto { Key = i.Key, Total = i.Total - e.Total }).ToList();

        var userStatistics = new UserStatisticsDto
        {
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance,
            IncomePerMonth = incomePerMonth,
            ExpensePerMonth = expensePerMonth,
            BalancePerMonth = balancePerMonth,
            IncomePerCategory = incomesPerCategory,
            ExpensePerCategory = expensesPerCategory,
            BalancePerCategory = balancePerCategory
        };

        return retval.SetOk(userStatistics);
    }



}
