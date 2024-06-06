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
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<IncomeDto> Get(int id)
    {
        var userId = GetUserId();
        var retval = incomeFacade.GetIncomeById(id, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetAll")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public ActionResult<List<IncomeDto>> GetAll()
    {
        var userId = GetUserId();
        var retval = incomeFacade.GetAllIncomesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public ActionResult<IncomeDto> Post(IncomeDto incomeDto)
    {
        var userId = GetUserId();
        var retval = incomeFacade.SetIncome(incomeDto, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public ActionResult<bool> Delete(int incomeId)
    {
        var userId = GetUserId();
        var retval = incomeFacade.DeleteIncome(incomeId, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete("DeleteAll")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public ActionResult<bool> DeleteAll()
    {
        var userId = GetUserId();
        var retval = incomeFacade.DeleteAllIncomes(userId);
        return FacadeResponseToActionResult(retval);
    }
}
