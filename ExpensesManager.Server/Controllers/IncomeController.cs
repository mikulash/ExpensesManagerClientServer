using System.Security.Claims;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IncomeController(IncomeFacade incomeFacade) : ApiControllerBase
{
    [HttpGet]
    public IActionResult Get(int id)
    {
        var retval = incomeFacade.GetIncomeById(id);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var retval = incomeFacade.GetAllIncomesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    public IActionResult Post(IncomeDto incomeDto)
    {
        var retval = incomeFacade.SetIncome(incomeDto);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    public IActionResult Delete(int incomeId)
    {
        var retval = incomeFacade.DeleteIncome(incomeId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete("DeleteAll")]
    public IActionResult DeleteAll()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var retval = incomeFacade.DeleteAllIncomes(userId);
        return FacadeResponseToActionResult(retval);
    }
}
