using System.Net.Http.Headers;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.IntegrationTests.Utilities;
using ExpensesManager.Server.Mappings;
using Microsoft.AspNetCore.Identity;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class AuthenticatedBaseTest : BaseTest
{
    protected UserDto User;

    protected AuthenticatedBaseTest(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper) :
        base(factory, testOutputHelper)
    {
        Factory.ResetDatabaseAsync().GetAwaiter().GetResult(); // Reset the database before each test
        var newUser = MockDataFactory.CreateUsers()[0];
        RegisterUser(newUser).Wait();
        User = LoginUser(newUser).Result;
        InitUserData().Wait();
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

    private async Task InitUserData()
    {
        var categoryId = await GetBaseCategory();
        await AddIncomes(categoryId);
        await AddExpenses(categoryId);
    }

    private async Task<int> GetBaseCategory()
    {
        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);
        return categoriesResponse[0].Id;
    }

    private async Task AddIncomes(int categoryId)
    {
        var incomes = MockDataFactory.CreateIncomes(User.UserId, categoryId);
        foreach (var incomeDto in incomes.Select(IncomeMapping.ToIncomeDto))
        {
            var response = await Client.PostAsJsonAsync("/api/Income/AddOrUpdate", incomeDto);
            Assert.True(response.IsSuccessStatusCode);
        }
    }

    private async Task AddExpenses(int categoryId)
    {
        var expenses = MockDataFactory.CreateExpenses(User.UserId, categoryId);
        foreach (var expenseDto in expenses.Select(ExpenseMapping.ToExpenseDto))
        {
            var response = await Client.PostAsJsonAsync("/api/Expense/AddOrUpdate", expenseDto);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
