using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IUserFacade userFacade) : ApiControllerBase
{
    [HttpGet]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<UserDto> GetUser()
    {
        var userId = GetUserId();
        var retval = userFacade.GetUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("Balance")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<decimal> GetCurrentUserBalance()
    {
        var userId = GetUserId();
        var retval = userFacade.GetCurrentBalance(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("TotalIncome")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<decimal> GetTotalIncome()
    {
        var userId = GetUserId();
        var totalIncome = userFacade.GetTotalIncome(userId);
        return FacadeResponseToActionResult(totalIncome);
    }

    [HttpGet("TotalExpense")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<decimal> GetTotalExpense()
    {
        var userId = GetUserId();
        var totalExpense = userFacade.GetTotalExpense(userId);
        return FacadeResponseToActionResult(totalExpense);
    }

    [HttpGet("FilteredTransactions")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
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
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<UserTransactionsDto> ExportData()
    {
        var userId = GetUserId();
        var retval = userFacade.GetAllTransactions(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("ImportData")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public ActionResult<bool> ImportData(UserImportDataDto userTransactionsDto)
    {
        var userId = GetUserId();
        var retval = userFacade.ImportData(userTransactionsDto, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("Statistics")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<UserStatisticsDto> GetStatistics()
    {
        var userId = GetUserId();
        var statistics = userFacade.GetStatistics(userId);
        return FacadeResponseToActionResult(statistics);
    }

    [HttpGet("StatisticsGraph")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<FileStreamResult> GetStatsGraph()
    {
        var userId = GetUserId();
        var retval = userFacade.GetStatsGraph(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete("DeleteAll")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public ActionResult<bool> DeleteAll()
    {
        var userId = GetUserId();
        var retval = userFacade.DeleteAllTransactions(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("Backup")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public ActionResult<bool> BackupUserData(UserImportDataDto data)
    {
        var userId = GetUserId();
        var retval = userFacade.BackupUserData(data, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("Restore")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public ActionResult<bool> RestoreUserData()
    {
        var userId = GetUserId();
        var retval = userFacade.RestoreUserData(userId);
        return FacadeResponseToActionResult(retval);
    }


}
