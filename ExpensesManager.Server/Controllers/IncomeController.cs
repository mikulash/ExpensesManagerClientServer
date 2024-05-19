
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IncomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(int id)
    {
        var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(new { Message = "This is protected data.", UserId = userID });
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
