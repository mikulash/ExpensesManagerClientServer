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
        var email = "test@test.cz";
        var password = "Test1234";
        var registration = new RegistrationDto
        {
            Email = email,
            Password = password,
            ConfirmPassword = password
        };

        var response = Client.PostAsJsonAsync("/api/Auth/register", registration).Result;
        Assert.True(response.IsSuccessStatusCode);

        var login = new LoginDto
        {
            Email = email,
            Password = password
        };

        response = Client.PostAsJsonAsync("/api/Auth/login", login).Result;
        Assert.True(response.IsSuccessStatusCode);

    }
}
