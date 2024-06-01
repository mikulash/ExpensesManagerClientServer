using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class BaseTest : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;
    protected readonly ITestOutputHelper TestOutputHelper;


    public BaseTest(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        Client = factory.CreateClient();
        TestOutputHelper = testOutputHelper;
    }


    public static T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ??
               throw new Exception("Deserialization failed");
    }
}