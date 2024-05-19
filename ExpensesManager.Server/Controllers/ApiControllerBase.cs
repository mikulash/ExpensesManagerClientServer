using ExpensesManager.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

public class ApiControllerBase : ControllerBase
{

    public IActionResult FacadeResponseToActionResult<T>(FacadeResponse<T> response)
    {
        return response.IsSuccess ? Ok(response.Value) : StatusCode(response.StatusCode, response.Message);
    }
}
