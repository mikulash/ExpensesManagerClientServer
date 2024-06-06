using System.Net;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.IntegrationTests.Utilities;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class ExpenseTest : AuthenticatedBaseTest
{
    public ExpenseTest(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper) : base(factory,
        testOutputHelper)
    {
    }

    [Fact]
    public async Task UserGetsExpenseById()
    {
        var expensesResponse = await Client.GetFromJsonAsync<List<ExpenseDto>>("/api/Expense/GetAll");
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        var expenseId = expensesResponse[0].Id;
        var response = await Client.GetAsync($"/api/Expense?id={expenseId}");
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task UserGetsExpensesByCategory()
    {
        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);

        var categoryId = categoriesResponse[0].Id;
        var response = await Client.GetAsync($"/api/Expense/GetByCategory?categoryId={categoryId}");
        Assert.True(response.IsSuccessStatusCode);

        var expensesResponse = await response.Content.ReadFromJsonAsync<List<ExpenseDto>>();
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        foreach (var expense in expensesResponse) Assert.Equal(categoryId, expense.CategoryId);
    }

    [Fact]
    public async Task UserGetsExpensesByDateRange()
    {
        var dateFrom = new DateTime(2021, 1, 1);
        var dateFromString = dateFrom.ToString("yyyy-MM-dd");
        var dateTo = new DateTime(2024, 12, 31);
        var dateToString = dateTo.ToString("yyyy-MM-dd");
        var response =
            await Client.GetAsync($"/api/Expense/GetByDateRange?startDate={dateFromString}&endDate={dateToString}");
        Assert.True(response.IsSuccessStatusCode);

        var expensesResponse = await response.Content.ReadFromJsonAsync<List<ExpenseDto>>();
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        foreach (var expense in expensesResponse) Assert.InRange(expense.Date, dateFrom, dateTo);
    }

    [Fact]
    public async Task UserGetsByAmountRange()
    {
        var amountFrom = 100;
        var amountTo = 1500;
        var response =
            await Client.GetAsync($"/api/Expense/GetByAmountRange?minAmount={amountFrom}&maxAmount={amountTo}");
        Assert.True(response.IsSuccessStatusCode);

        var expensesResponse = await response.Content.ReadFromJsonAsync<List<ExpenseDto>>();
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        foreach (var expense in expensesResponse) Assert.InRange(expense.Amount, amountFrom, amountTo);
    }

    [Fact]
    public async Task UserDeletesExpenseById()
    {
        var expensesResponse = await Client.GetFromJsonAsync<List<ExpenseDto>>("/api/Expense/GetAll");
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        var expenseId = expensesResponse[0].Id;
        var response = await Client.DeleteAsync($"/api/Expense?expenseId={expenseId}");
        Assert.True(response.IsSuccessStatusCode);

        response = await Client.GetAsync($"/api/Expense?id={expenseId}");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task UserDeletesAllExpenses()
    {
        var expensesResponse = await Client.GetFromJsonAsync<List<ExpenseDto>>("/api/Expense/GetAll");
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        var response = await Client.DeleteAsync("/api/Expense/DeleteAll");
        Assert.True(response.IsSuccessStatusCode);

        response = await Client.GetAsync("/api/Expense/GetAll");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
