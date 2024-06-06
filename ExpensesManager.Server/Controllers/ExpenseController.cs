using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ExpenseController(IExpenseFacade expenseFacade) : ApiControllerBase
{
    [HttpGet]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<ExpenseDto> Get(int id)
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetExpenseById(id, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public ActionResult<ExpenseDto> Post(ExpenseDto expenseDto)
    {
        var userId = GetUserId();
        var retval = expenseFacade.SetExpense(expenseDto, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public ActionResult<bool> Delete(int expenseId)
    {
        var userId = GetUserId();
        var retval = expenseFacade.DeleteExpense(expenseId, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete("DeleteAll")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public ActionResult<bool> DeleteAll()
    {
        var userId = GetUserId();
        var retval = expenseFacade.DeleteAllExpenses(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetAll")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<List<ExpenseDto>> GetAll()
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetAllExpensesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByCategory")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<List<ExpenseDto>> GetByCategory(int categoryId)
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetExpensesByCategory(userId, categoryId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByDateRange")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<List<ExpenseDto>> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetExpensesByDateRange(userId, startDate, endDate);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByAmountRange")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<List<ExpenseDto>> GetByAmountRange(decimal minAmount, decimal maxAmount)
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetExpensesByAmountRange(userId, minAmount, maxAmount);
        return FacadeResponseToActionResult(retval);
    }
}
