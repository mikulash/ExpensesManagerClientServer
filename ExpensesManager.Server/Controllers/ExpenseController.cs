using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ExpenseController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(new { Message = "This is protected data.", UserId = userId });
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok(new { Message = "This is protected data." });
    }

    [HttpPut]
    public IActionResult Put()
    {
        return Ok(new { Message = "This is protected data." });
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok(new { Message = "This is protected data." });
    }
}
