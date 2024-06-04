using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IncomeController(IIncomeFacade incomeFacade) : ApiControllerBase
{
    [HttpGet]
    public ActionResult<IncomeDto> Get(int id)
    {
        var retval = incomeFacade.GetIncomeById(id);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetAll")]
    public ActionResult<List<IncomeDto>> GetAll()
    {
        var userId = GetUserId();
        var retval = incomeFacade.GetAllIncomesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    public ActionResult<IncomeDto> Post(IncomeDto incomeDto)
    {
        var userId = GetUserId();
        if (userId != incomeDto.UserId) return Unauthorized(new { Success = false, Message = "Unauthorized" });
        var retval = incomeFacade.SetIncome(incomeDto);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    public ActionResult<bool> Delete(int incomeId)
    {
        var retval = incomeFacade.DeleteIncome(incomeId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete("DeleteAll")]
    public ActionResult<bool> DeleteAll()
    {
        var userId = GetUserId();
        var retval = incomeFacade.DeleteAllIncomes(userId);
        return FacadeResponseToActionResult(retval);
    }
}
