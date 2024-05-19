using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(int id)
    {
        return Ok(new { Message = "This is protected data." });
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
