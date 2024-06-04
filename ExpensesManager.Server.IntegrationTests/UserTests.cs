using System.Net.Http.Headers;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.IntegrationTests.Utilities;
using ExpensesManager.Server.Mappings;
using Microsoft.AspNetCore.Identity;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class UserTests : BaseTest
{
    public UserTests(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper) : base(factory,
        testOutputHelper)
    {
    }

    [Fact]
    public async Task UserFirstAccess()
    {
        const string email = "test@test.cz";
        const string password = "Test_1234";
        var registration = MockDataFactory.CreateRegistrationDto(email, password);
        var login = MockDataFactory.CreateLoginDto(email, password);

        var response = await Client.PostAsJsonAsync("/api/Auth/register", registration);
        Assert.True(response.IsSuccessStatusCode);

        response = await Client.PostAsJsonAsync("/api/Auth/login", login);
        Assert.True(response.IsSuccessStatusCode);
        var loginResult = await response.Content.ReadFromJsonAsync<LoginSuccessDto>();
        Assert.NotNull(loginResult);
        Assert.NotNull(loginResult.Token);

        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);

        response = await Client.PostAsJsonAsync("/api/User", login);
        Assert.True(response.IsSuccessStatusCode);
        var userResult = await response.Content.ReadFromJsonAsync<UserDto>();
        Assert.NotNull(userResult);
        Assert.Equal(email, userResult.Email);
    }

    [Fact]
    public async Task UserSetsTransactionsToPredefinedCategories()
    {
        var user = MockDataFactory.CreateUsers()[0];
        await RegisterUser(user);
        var userDto = await LoginUser(user);

        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);

        var incomes = MockDataFactory.CreateIncomes(userDto.UserId, categoriesResponse[2].Id);
        var expenses = MockDataFactory.CreateExpenses(userDto.UserId, categoriesResponse[0].Id);
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
        var user = MockDataFactory.CreateUsers()[0];
        await RegisterUser(user);
        var userDto = await LoginUser(user);

        var category = MockDataFactory.CreateCategories(userDto.UserId)[0];
        var categoryDto = CategoryMapping.ToCategoryDto(category);
        var categoryResponse = await Client.PostAsJsonAsync("/api/Category/AddOrUpdate", categoryDto);
        categoryResponse.EnsureSuccessStatusCode();
        categoryDto = await categoryResponse.Content.ReadFromJsonAsync<CategoryDto>();
        Assert.True(categoryResponse.IsSuccessStatusCode);
        Assert.NotNull(categoryDto);

        var categoryCheckResponse = await Client.GetFromJsonAsync<CategoryDto>($"api/category?id={categoryDto.Id}");
        Assert.NotNull(categoryCheckResponse);

        var incomes = MockDataFactory.CreateIncomes(userDto.UserId, categoryDto.Id);
        var expenses = MockDataFactory.CreateExpenses(userDto.UserId, categoryDto.Id);

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

    private async Task<UserDto> LoginUser(IdentityUser user)
    {
        var login = MockDataFactory.CreateLoginDto(user);
        var response = await Client.PostAsJsonAsync("/api/Auth/login", login);
        Assert.True(response.IsSuccessStatusCode);
        var loginResult = await response.Content.ReadFromJsonAsync<LoginSuccessDto>();
        Assert.NotNull(loginResult);
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);
        return loginResult.User;
    }

    private async Task RegisterUser(IdentityUser user)
    {
        if (user.Email != null)
        {
            var registration = MockDataFactory.CreateRegistrationDto(user.Email, MockDataFactory.password);
            var response = await Client.PostAsJsonAsync("/api/Auth/register", registration);
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            throw new ArgumentNullException(nameof(user.Email));
        }

    }


}
