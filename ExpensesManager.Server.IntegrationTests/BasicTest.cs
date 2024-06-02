using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class BasicTest : BaseTest
{
    public BasicTest(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper) : base(factory,
        testOutputHelper)
    {
    }

    [Fact]
    public void LoadingEndpoints_EndpointsFound()
    {
        var endpointDataSource = Factory.Services.GetRequiredService<EndpointDataSource>();
        var endpoints = endpointDataSource.Endpoints;
        foreach (var endpoint in endpoints)
        {
            TestOutputHelper.WriteLine(endpoint.DisplayName);
        }

        Assert.NotEmpty(endpoints);
    }
}
