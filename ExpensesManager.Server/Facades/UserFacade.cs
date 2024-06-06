using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;
using ScottPlot;
using ScottPlot.Palettes;
using ScottPlot.TickGenerators;

namespace ExpensesManager.Server.Facades;

public interface IUserFacade
{
    FacadeResponse<UserDto> GetUser(string userId);
    FacadeResponse<decimal> GetCurrentBalance(string userId);
    FacadeResponse<decimal> GetTotalIncome(string userId);
    FacadeResponse<decimal> GetTotalExpense(string userId);
    FacadeResponse<UserTransactionsDto> GetFilteredTransactions(string userId, List<int>? categoryIds,
        DateTime? dateFrom, DateTime? dateTo);

    FacadeResponse<UserTransactionsDto> GetAllTransactions(string userId);
    FacadeResponse<bool> ImportData(UserTransactionsDto transactions, string userId);
    FacadeResponse<UserStatisticsDto> GetStatistics(string userId);
    FacadeResponse<bool> DeleteAllTransactions(string userId);
    FacadeResponse<MemoryStream> GetStatsGraph(string userId);
}

public class UserFacade(IUserService userService, IIncomeService incomeService, IExpenseService expenseService)
    : IUserFacade
{
    private const string invalidUserIdMessage = "User ID cannot be 0.";

    public FacadeResponse<UserDto> GetUser(string userId)
    {
        var retval = new FacadeResponse<UserDto>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var user = userService.GetUser(userId);
        if (user == null) return retval.SetNotFound("User not found.");
        return retval.SetOk(user);
    }
    public FacadeResponse<decimal> GetCurrentBalance(string userId)
    {
        var retval = new FacadeResponse<decimal>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var balance = userService.GetCurrentBalance(userId);
        return retval.SetOk(balance);
    }

    public FacadeResponse<decimal> GetTotalIncome(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var totalIncome = userService.GetTotalIncome(userId);
        return retval.SetOk(totalIncome);
    }

    public FacadeResponse<decimal> GetTotalExpense(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var totalExpense = userService.GetTotalExpense(userId);
        return retval.SetOk(totalExpense);
    }

    public FacadeResponse<UserTransactionsDto> GetFilteredTransactions(string userId, List<int>? categoryIds,
        DateTime? dateFrom, DateTime? dateTo)
    {
        var retval = new FacadeResponse<UserTransactionsDto>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);

        var incomes = incomeService.GetIncomesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();
        var expenses = expenseService.GetExpensesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var userTransactions = new UserTransactionsDto
        {
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
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);

        var incomes = incomeService.GetAllIncomesByUser(userId);
        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();
        var expenses = expenseService.GetAllExpensesByUser(userId);
        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var userTransactions = new UserTransactionsDto
        {
            Incomes = incomesDto,
            Expenses = expensesDto,
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance
        };

        return retval.SetOk(userTransactions);
    }

    public FacadeResponse<bool> ImportData(UserTransactionsDto transactions, string userId)
    {
        var retval = new FacadeResponse<bool>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);

        var incomes = transactions.Incomes.Select(i => IncomeMapping.ToIncome(i, userId)).ToList();
        var expenses = transactions.Expenses.Select(e => ExpenseMapping.ToExpense(e, userId)).ToList();

        var incomeResult = incomeService.SetIncomes(incomes);
        var expenseResult = expenseService.SetExpenses(expenses);

        return retval.SetOk(incomeResult && expenseResult);
    }

    public FacadeResponse<UserStatisticsDto> GetStatistics(string userId)
    {
        var retval = new FacadeResponse<UserStatisticsDto>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var userStatistics = userService.GetStatistics(userId);
        return retval.SetOk(userStatistics);
    }

    public FacadeResponse<bool> DeleteAllTransactions(string userId)
    {
        var retval = new FacadeResponse<bool>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var incomeResult = incomeService.DeleteAllIncomes(userId);
        var expenseResult = expenseService.DeleteAllExpenses(userId);
        return retval.SetOk(incomeResult && expenseResult);
    }

    public FacadeResponse<MemoryStream> GetStatsGraph(string userId)
    {

        var retval = new FacadeResponse<MemoryStream>();
        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized(invalidUserIdMessage);
        var userStatistics = userService.GetStatistics(userId);

        var plt = new Plot();
        plt.Title("Income vs Expense");
        plt.YLabel("Amount");
        plt.XLabel("Month");

        var months = userStatistics.IncomePerMonth.Select(i => i.Key).ToArray();
        var incomePerMonth = userStatistics.IncomePerMonth.Select(i => i.Total).Select(i => (double)i).ToArray();
        var expensePerMonth = userStatistics.ExpensePerMonth.Select(e => e.Total).Select(i => (double)i).ToArray();
        var balancePerMonth = userStatistics.BalancePerMonth.Select(b => b.Total).Select(i => (double)i).ToArray();

        Category10 palette = new();

        var bars = new List<Bar>();

        for (var i = 0; i < months.Length; i++)
        {
            bars.Add(new Bar
                { Position = i * 3 + 1, Value = incomePerMonth[i], FillColor = palette.GetColor(0), Error = 0 });
            bars.Add(new Bar
                { Position = i * 3 + 2, Value = expensePerMonth[i], FillColor = palette.GetColor(1), Error = 0 });
            bars.Add(new Bar
                { Position = i * 3 + 3, Value = balancePerMonth[i], FillColor = palette.GetColor(2), Error = 0 });
        }

        plt.Add.Bars(bars.ToArray());

        plt.Legend.IsVisible = true;
        plt.Legend.Alignment = Alignment.UpperLeft;
        plt.Legend.ManualItems.Add(new LegendItem { LabelText = "Income", FillColor = palette.GetColor(0) });
        plt.Legend.ManualItems.Add(new LegendItem { LabelText = "Expense", FillColor = palette.GetColor(1) });
        plt.Legend.ManualItems.Add(new LegendItem { LabelText = "Balance", FillColor = palette.GetColor(2) });

        var ticks = new List<Tick>();

        for (var i = 0; i < months.Length; i++) ticks.Add(new Tick(i * 3 + 2, months[i].ToString()));

        plt.Axes.Bottom.TickGenerator = new NumericManual(ticks.ToArray());
        plt.Axes.Bottom.MajorTickStyle.Length = 0;
        plt.HideGrid();
        plt.Axes.Margins(bottom: 0);

        var tempFilePath = Path.GetRandomFileName();
        try
        {
            // Save the plot to the temporary file
            plt.SavePng(tempFilePath, 600, 400);

            // Read the file into a memory stream
            var stream = new MemoryStream();
            using (var fileStream = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read))
            {
                fileStream.CopyTo(stream);
            }

            stream.Position = 0;

            return retval.SetOk(stream);
        }
        finally
        {
            // Delete the temporary file
            if (File.Exists(tempFilePath)) File.Delete(tempFilePath);
        }
    }
}
