using ExpensesManager.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

public class ApiControllerBase : ControllerBase
{
    protected IActionResult FacadeResponseToActionResult<T>(FacadeResponse<T> response) where T : notnull
    {
        return response.IsSuccess ? Ok(response.Value) : StatusCode(response.StatusCode, response.Message);
    }
}
