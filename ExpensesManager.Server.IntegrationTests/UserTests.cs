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
    public void UserFirstAccess()
    {
        var email = "test@test.cz";
        var password = "Test_1234";
        var registration = new RegistrationDto
        {
            Email = email,
            Password = password,
            ConfirmPassword = password
        };

        var response = Client.PostAsJsonAsync("/api/Auth/register", registration).Result;
        Assert.True(response.IsSuccessStatusCode);
        var registerResult = response.Content.ReadFromJsonAsync<RegistrationSuccessDto>().Result;

        var login = new LoginDto
        {
            Email = email,
            Password = password
        };

        response = Client.PostAsJsonAsync("/api/Auth/login", login).Result;
        Assert.True(response.IsSuccessStatusCode);
        var loginResult = response.Content.ReadFromJsonAsync<LoginSuccessDto>().Result;
        Assert.NotNull(loginResult);
        Assert.NotNull(loginResult.Token);

        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);

        response = Client.PostAsJsonAsync("/api/User", login).Result;
        Assert.True(response.IsSuccessStatusCode);
        var userResult = response.Content.ReadFromJsonAsync<UserDto>().Result;
        Assert.NotNull(userResult);
        Assert.Equal(email, userResult.Email);
    }
}
