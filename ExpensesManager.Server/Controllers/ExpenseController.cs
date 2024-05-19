using System.Security.Claims;
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
    public IActionResult Get(int id)
    {
        var retval = expenseFacade.GetExpenseById(id);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    public IActionResult Post(ExpenseDto expenseDto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var retval = expenseFacade.SetExpense(userId, expenseDto);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    public IActionResult Delete(int expenseId)
    {
        var retval = expenseFacade.DeleteExpense(expenseId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var retval = expenseFacade.GetAllExpensesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByCategory")]
    public IActionResult GetByCategory(int categoryId)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var retval = expenseFacade.GetExpensesByCategory(userId, categoryId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByDateRange")]
    public IActionResult GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var retval = expenseFacade.GetExpensesByDateRange(userId, startDate, endDate);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetByAmountRange")]
    public IActionResult GetByAmountRange(decimal minAmount, decimal maxAmount)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var retval = expenseFacade.GetExpensesByAmountRange(userId, minAmount, maxAmount);
        return FacadeResponseToActionResult(retval);
    }
}