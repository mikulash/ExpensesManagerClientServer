using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.IntegrationTests.Utilities;
using ExpensesManager.Server.Mappings;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class UserTests : AuthenticatedBaseTest
{
    public UserTests(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper) : base(factory,
        testOutputHelper)
    {
    }

    [Fact]
    public async Task UserSetsTransactionsToPredefinedCategories()
    {
        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);

        var incomes = MockDataFactory.CreateIncomes(User.UserId, categoriesResponse[2].Id);
        var expenses = MockDataFactory.CreateExpenses(User.UserId, categoriesResponse[0].Id);
        var incomeDto = IncomeMapping.ToIncomeDto(incomes[0]);
        var expenseDto = ExpenseMapping.ToExpenseDto(expenses[0]);

        var response = await Client.PostAsJsonAsync("/api/Income/AddOrUpdate", incomeDto);
        Assert.True(response.IsSuccessStatusCode);

        response = await Client.PostAsJsonAsync("/api/Expense/AddOrUpdate", expenseDto);
        Assert.True(response.IsSuccessStatusCode);

        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);
    }

    [Fact]
    public async Task UserSetsTransactionsToCustomCategories()
    {
        var category = MockDataFactory.CreateCategories(User.UserId)[0];
        var categoryDto = CategoryMapping.ToCategoryDto(category);
        var categoryResponse = await Client.PostAsJsonAsync("/api/Category/AddOrUpdate", categoryDto);
        categoryResponse.EnsureSuccessStatusCode();
        categoryDto = await categoryResponse.Content.ReadFromJsonAsync<CategoryDto>();
        Assert.True(categoryResponse.IsSuccessStatusCode);
        Assert.NotNull(categoryDto);

        var categoryCheckResponse = await Client.GetFromJsonAsync<CategoryDto>($"api/category?id={categoryDto.Id}");
        Assert.NotNull(categoryCheckResponse);

        var incomes = MockDataFactory.CreateIncomes(User.UserId, categoryDto.Id);
        var expenses = MockDataFactory.CreateExpenses(User.UserId, categoryDto.Id);

        var incomeDto = IncomeMapping.ToIncomeDto(incomes[0]);
        var expenseDto = ExpenseMapping.ToExpenseDto(expenses[0]);

        var response = await Client.PostAsJsonAsync("/api/Income/AddOrUpdate", incomeDto);
        Assert.True(response.IsSuccessStatusCode);

        response = await Client.PostAsJsonAsync("/api/Expense/AddOrUpdate", expenseDto);
        Assert.True(response.IsSuccessStatusCode);

        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);
    }




}
