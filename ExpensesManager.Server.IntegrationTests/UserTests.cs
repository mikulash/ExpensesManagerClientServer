using System.Net.Http.Headers;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.DTOs.Auth;
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
}
