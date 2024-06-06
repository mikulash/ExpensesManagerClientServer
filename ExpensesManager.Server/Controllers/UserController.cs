using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IUserFacade userFacade, UserManager<IdentityUser> userManager) : ApiControllerBase
{
    [HttpGet]
    public ActionResult<UserDto> GetUser()
    {
        var userId = GetUserId();
        var retval = userFacade.GetUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("Balance")]
    public ActionResult<decimal> GetCurrentUserBalance()
    {
        var userId = GetUserId();
        var retval = userFacade.GetCurrentBalance(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("TotalIncome")]
    public ActionResult<decimal> GetTotalIncome()
    {
        var userId = GetUserId();
        var totalIncome = userFacade.GetTotalIncome(userId);
        return FacadeResponseToActionResult(totalIncome);
    }

    [HttpGet("TotalExpense")]
    public ActionResult<decimal> GetTotalExpense()
    {
        var userId = GetUserId();
        var totalExpense = userFacade.GetTotalExpense(userId);
        return FacadeResponseToActionResult(totalExpense);
    }

    [HttpGet("FilteredTransactions")]
    public ActionResult<UserTransactionsDto> GetFilteredExpenses(
        [FromQuery] List<int>? categories = null,
        [FromQuery] DateTime? dateFrom = null,
        [FromQuery] DateTime? dateTo = null)
    {
        var userId = GetUserId();
        var expenses = userFacade.GetFilteredTransactions(userId, categories, dateFrom, dateTo);
        return FacadeResponseToActionResult(expenses);
    }

    [HttpGet("ExportData")]
    public ActionResult<UserTransactionsDto> ExportData()
    {
        var userId = GetUserId();
        var retval = userFacade.GetAllTransactions(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("ImportData")]
    public ActionResult<bool> ImportData(UserTransactionsDto userTransactionsDto)
    {
        var userId = GetUserId();
        var retval = userFacade.ImportData(userTransactionsDto, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("Statistics")]
    public ActionResult<UserStatisticsDto> GetStatistics()
    {
        var userId = GetUserId();
        var statistics = userFacade.GetStatistics(userId);
        return FacadeResponseToActionResult(statistics);
    }

    [HttpGet("StatsGraph")]
    public ActionResult<MemoryStream> GetStatsGraph()
    {
        var userId = GetUserId();
        var retval = userFacade.GetStatsGraph(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete("DeleteAll")]
    public ActionResult<bool> DeleteAll()
    {
        var userId = GetUserId();
        var retval = userFacade.DeleteAllTransactions(userId);
        return FacadeResponseToActionResult(retval);
    }

}
