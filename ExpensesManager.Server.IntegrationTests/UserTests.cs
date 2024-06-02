using System.Net.Http.Headers;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.DTOs.Auth;
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
        // var expenses = MockDataFactory.CreateExpenses(user.Id, categoriesResponse[0].Id);

        var response = await Client.PostAsJsonAsync("/api/Income/AddOrUpdate", incomes[0]);
        Assert.True(response.IsSuccessStatusCode);

        // response = await Client.PostAsJsonAsync("/api/Expense/AddOrUpdate", expenses[0]);
        // Assert.True(response.IsSuccessStatusCode);

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
        var registration = MockDataFactory.CreateRegistrationDto(user.Email, MockDataFactory.password);
        var response = await Client.PostAsJsonAsync("/api/Auth/register", registration);
        Assert.True(response.IsSuccessStatusCode);
    }


}
