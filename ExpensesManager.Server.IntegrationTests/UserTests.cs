using System.Net.Http.Headers;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.DTOs.Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class UserTests : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly ITestOutputHelper TestOutputHelper;
    private readonly WebApplicationFactory<Program> _factory;
    protected readonly HttpClient Client;

    public UserTests(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
        _factory = factory;
        Client = factory.CreateClient();
    }

    [Fact]
    public void UserFirstAccess()
    {
        var randPrefix = Guid.NewGuid().ToString().Substring(0, 3);
        var email = randPrefix + "test@test.cz";
        var password = "Test_1234";
        var registration = new RegistrationDto
        {
            Email = email,
            Password = password,
            ConfirmPassword = password
        };

        var response = Client.PostAsJsonAsync("/api/Auth/register", registration).Result;
        var registerResult = response.Content.ReadFromJsonAsync<RegistrationSuccessDto>().Result;
        Assert.True(response.IsSuccessStatusCode);

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
