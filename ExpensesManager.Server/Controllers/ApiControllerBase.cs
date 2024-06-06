using System.Security.Claims;
using ExpensesManager.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

public class ApiControllerBase : ControllerBase
{
    protected ActionResult<T> FacadeResponseToActionResult<T>(FacadeResponse<T> response) where T : notnull
    {
        if (response.IsSuccess) return Ok(response.Value);
        if (response.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(response.Message);
        if (response.StatusCode == StatusCodes.Status403Forbidden)
        {
            HttpContext.Response.Headers.Append("X-Error-Message", response.Message);
            return Forbid();
        }

        if (response.StatusCode == StatusCodes.Status404NotFound) return NotFound(response.Message);

        return StatusCode(response.StatusCode, response.Message);
    }

    protected string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }
}
