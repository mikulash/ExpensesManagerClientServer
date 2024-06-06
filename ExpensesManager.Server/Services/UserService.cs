using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Repositories;
using Microsoft.AspNetCore.Identity;
using ScottPlot;
using ScottPlot.Palettes;
using ScottPlot.TickGenerators;

namespace ExpensesManager.Server.Services;

public interface IUserService
{
    decimal GetCurrentBalance(string userId);
    decimal GetTotalIncome(string userId);
    decimal GetTotalExpense(string userId);
    UserStatisticsDto GetStatistics(string userId);
    MemoryStream? GetStatsGraph(string userId);
    void InitNewUser(string userId);
    UserDto? GetUser(string userId);
    bool BackupUserData(string userId);
    bool RestoreUserData(string userId);
}

public class UserService(
    IIncomeService incomeService,
    IExpenseService expenseService,
    ICategoryService categoryService,
    ICloudRepository cloudRepository,
    UserManager<IdentityUser> userManager)
    : IUserService
{
    public UserDto? GetUser(string userId)
    {
        var user = userManager.FindByIdAsync(userId).Result;
        if (user == null) return null;

        return new UserDto
        {
            UserId = userId,
            Username = user.UserName,
            Email = user.Email
        };
    }

    public bool BackupUserData(string userId)
    {
        var data = new UserImportDataDto
        {
            Incomes = incomeService.GetAllIncomesByUser(userId).Select(IncomeMapping.ToIncomeDto).ToList(),
            Expenses = expenseService.GetAllExpensesByUser(userId).Select(ExpenseMapping.ToExpenseDto).ToList(),
            Categories = categoryService.GetAllCategoriesByUser(userId).Select(CategoryMapping.ToCategoryDto).ToList()
        };
        var isSuccess = cloudRepository.BackupUserData(data, userId).Result;
        return isSuccess;
    }

    public bool RestoreUserData(string userId)
    {
        var data = cloudRepository.RestoreUserData(userId).Result;
        if (data == null) return false;

        var incomes = data.Incomes.Select(income => IncomeMapping.ToIncome(income, userId)).ToList();
        var expenses = data.Expenses.Select(expense => ExpenseMapping.ToExpense(expense, userId)).ToList();
        var categories = data.Categories.Select(category => CategoryMapping.ToCategory(category, userId)).ToList();

        var isCategorySet = categoryService.SetCategories(categories);
        var isIncomeSet = incomeService.SetIncomes(incomes);
        var isExpenseSet = expenseService.SetExpenses(expenses);

        return isIncomeSet && isExpenseSet && isCategorySet;
    }

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

    public UserStatisticsDto GetStatistics(string userId)
    {
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

        return userStatistics;
    }

    public MemoryStream? GetStatsGraph(string userId)
    {
        var userStatistics = GetStatistics(userId);
        if (userStatistics is { TotalIncome: 0, TotalExpense: 0 }) return null;

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

            return stream;
        }
        finally
        {
            // Delete the temporary file
            if (File.Exists(tempFilePath)) File.Delete(tempFilePath);
        }
    }

    public void InitNewUser(string userId)
    {
        var categories = CategoryService.CreateDefaultCategories(userId);
        categoryService.SetCategories(categories);
    }
}
