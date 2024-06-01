using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class BaseTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;
    protected readonly ITestOutputHelper TestOutputHelper;
    protected readonly CustomWebApplicationFactory<Program> Factory;


    protected BaseTest(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        Client = factory.CreateClient();
        TestOutputHelper = testOutputHelper;
        Factory = factory;
    }
}
