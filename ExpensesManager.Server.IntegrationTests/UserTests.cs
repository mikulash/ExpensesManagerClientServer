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

    [Fact]
    public async Task UserGetAllData()
    {
        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);

        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);

        var expensesResponse = await Client.GetFromJsonAsync<List<ExpenseDto>>("/api/Expense/GetAll");
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        var exportedDataResponse = await Client.GetFromJsonAsync<UserTransactionsDto>("api/User/ExportData");
        Assert.NotNull(exportedDataResponse);
        Assert.NotNull(exportedDataResponse.Incomes);
        Assert.NotNull(exportedDataResponse.Expenses);
    }

    [Fact]
    public async Task UserGetFilteredData()
    {
        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);

        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);

        var expensesResponse = await Client.GetFromJsonAsync<List<ExpenseDto>>("/api/Expense/GetAll");
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);

        var filteredDataResponse = await Client.GetFromJsonAsync<UserTransactionsDto>("api/User/FilteredTransactions");
        Assert.NotNull(filteredDataResponse);
        Assert.NotNull(filteredDataResponse.Incomes);
        Assert.NotNull(filteredDataResponse.Expenses);
    }

    [Fact]
    public async Task UserGetBalance()
    {
        var balanceResponse = await Client.GetFromJsonAsync<decimal>("api/User/Balance");
        Assert.True(balanceResponse >= 0);
    }

    [Fact]
    public async Task UserGetTotalIncome()
    {
        var totalIncomeResponse = await Client.GetFromJsonAsync<decimal>("api/User/TotalIncome");
        Assert.True(totalIncomeResponse >= 0);
    }

    [Fact]
    public async Task UserGetTotalExpense()
    {
        var totalExpenseResponse = await Client.GetFromJsonAsync<decimal>("api/User/TotalExpense");
        Assert.True(totalExpenseResponse >= 0);
    }

    [Fact]
    public async Task UserGetUser()
    {
        var userResponse = await Client.GetFromJsonAsync<UserDto>("api/User/");
        Assert.NotNull(userResponse);
        Assert.NotNull(userResponse.UserId);
        Assert.NotNull(userResponse.Username);
        Assert.NotNull(userResponse.Email);
    }

    [Fact]
    public async Task UserDeleteAllData()
    {
        var response = await Client.DeleteAsync("api/User/DeleteAll");
        Assert.True(response.IsSuccessStatusCode);

        var totalExpenseResponse = await Client.GetFromJsonAsync<decimal>("api/User/TotalExpense");
        Assert.True(totalExpenseResponse == 0);
    }

    [Fact]
    public async Task ImportUserData()
    {
        var userImportData = MockDataFactory.CreateUserDataForImport(User.UserId);
        var response = await Client.PostAsJsonAsync("api/User/ImportData", userImportData);
        Assert.True(response.IsSuccessStatusCode);

        var totalExpenseResponse = await Client.GetFromJsonAsync<decimal>("api/User/TotalExpense");
        Assert.True(totalExpenseResponse > 0);

        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);
        Assert.Contains(incomesResponse, i => userImportData.Incomes.Exists(ui => ui.Amount == i.Amount));

        var expensesResponse = await Client.GetFromJsonAsync<List<ExpenseDto>>("/api/Expense/GetAll");
        Assert.NotNull(expensesResponse);
        Assert.NotEmpty(expensesResponse);
        Assert.Contains(expensesResponse, e => userImportData.Expenses.Exists(ui => ui.Amount == e.Amount));

        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);
        Assert.Contains(categoriesResponse, c => userImportData.Categories.Exists(ui => ui.Name == c.Name));
    }

    [Fact]
    public async Task BackupUserData()
    {
        var response = await Client.PostAsync("api/User/Backup", null);
        Assert.True(response.IsSuccessStatusCode);
    }
}
