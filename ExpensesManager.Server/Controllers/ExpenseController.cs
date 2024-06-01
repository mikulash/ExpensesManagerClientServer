using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ExpenseController(ExpenseFacade expenseFacade) : ApiControllerBase
{
    [HttpGet]
    public ActionResult<ExpenseDto> Get(int id)
    {
        var retval = expenseFacade.GetExpenseById(id);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    public ActionResult<bool> Post(ExpenseDto expenseDto)
    {
        var userId = GetUserId();
        var retval = expenseFacade.SetExpense(userId, expenseDto);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    public ActionResult<bool> Delete(int expenseId)
    {
        var retval = expenseFacade.DeleteExpense(expenseId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetAll")]
    public ActionResult<List<ExpenseDto>> GetAll()
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetAllExpensesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByCategory")]
    public ActionResult<List<ExpenseDto>> GetByCategory(int categoryId)
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetExpensesByCategory(userId, categoryId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByDateRange")]
    public ActionResult<List<ExpenseDto>> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetExpensesByDateRange(userId, startDate, endDate);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByAmountRange")]
    public ActionResult<List<ExpenseDto>> GetByAmountRange(decimal minAmount, decimal maxAmount)
    {
        var userId = GetUserId();
        var retval = expenseFacade.GetExpensesByAmountRange(userId, minAmount, maxAmount);
        return FacadeResponseToActionResult(retval);
    }
}
