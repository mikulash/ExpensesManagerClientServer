using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class BasicTest : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly ITestOutputHelper TestOutputHelper;
    private readonly WebApplicationFactory<Program> _factory;
    protected readonly HttpClient Client;


    public BasicTest(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
        _factory = factory;
        Client = factory.CreateClient();

    }

    [Fact]
    public void LoadingEndpoints_EndpointsFound()
    {
        var endpointDataSource = _factory.Services.GetRequiredService<EndpointDataSource>();
        var endpoints = endpointDataSource.Endpoints;
        foreach (var endpoint in endpoints)
        {
            TestOutputHelper.WriteLine(endpoint.DisplayName);
        }
        Assert.NotEmpty(endpoints);
    }
}
