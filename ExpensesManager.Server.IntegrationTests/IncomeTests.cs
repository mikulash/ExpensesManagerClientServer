using System.Net;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.IntegrationTests.Utilities;
using ExpensesManager.Server.Mappings;
using Xunit.Abstractions;

namespace ExpensesManager.Server.IntegrationTests;

public class IncomeTests : AuthenticatedBaseTest
{
    public IncomeTests(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper) : base(factory,
        testOutputHelper)
    {
    }

    [Fact]
    public async Task UserGetsIncomeById()
    {
        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);

        var incomeId = incomesResponse[0].Id;
        var response = await Client.GetAsync($"/api/Income?id={incomeId}");
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task UserSetsIncome()
    {
        var categoriesResponse = await Client.GetFromJsonAsync<List<CategoryDto>>("/api/Category/GetAll");
        Assert.NotNull(categoriesResponse);
        Assert.NotEmpty(categoriesResponse);

        var incomes = MockDataFactory.CreateIncomes(User.UserId, categoriesResponse[2].Id);
        var incomeDto = IncomeMapping.ToIncomeDto(incomes[0]);

        var response = await Client.PostAsJsonAsync("/api/Income/AddOrUpdate", incomeDto);
        Assert.True(response.IsSuccessStatusCode);

        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);
    }

    [Fact]
    public async Task UserDeletesAllIncomes()
    {
        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);

        var response = await Client.DeleteAsync("/api/Income/DeleteAll");
        Assert.True(response.IsSuccessStatusCode);

        response = await Client.GetAsync("/api/Income/GetAll");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task UserDeletesIncome()
    {
        var incomesResponse = await Client.GetFromJsonAsync<List<IncomeDto>>("/api/Income/GetAll");
        Assert.NotNull(incomesResponse);
        Assert.NotEmpty(incomesResponse);

        var incomeId = incomesResponse[0].Id;
        var response = await Client.DeleteAsync($"/api/Income?incomeId={incomeId}");
        Assert.True(response.IsSuccessStatusCode);

        response = await Client.GetAsync($"/api/Income?incomeId={incomeId}");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
