using System.Security.Claims;
using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(UserFacade userFacade, UserManager<IdentityUser> userManager) : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserDto>> GetUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized(new { Success = false, Message = "Unauthorized" });

        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return NotFound(new { Success = false, Message = "User not found" });

        var userResponse = new UserDto
        {
            UserId = userId, Username = user.UserName, Email = user.Email
        };

        return Ok(userResponse);
    }

    // [HttpGet("User")]
    // public IActionResult GetUser()
    // {
    //     var user = userFacade.GetUser(userId);
    //     return FacadeResponseToActionResult(user);
    // }

    [HttpGet("Balance")]
    public IActionResult GetCurrentUserBalance(int userId)
    {
        var retval = userFacade.GetCurrentBalance(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("TotalIncome")]
    public IActionResult GetTotalIncome(int userId)
    {
        var totalIncome = userFacade.GetTotalIncome(userId);
        return FacadeResponseToActionResult(totalIncome);
    }

    [HttpGet("TotalExpense")]
    public IActionResult GetTotalExpense(int userId)
    {
        var totalExpense = userFacade.GetTotalExpense(userId);
        return FacadeResponseToActionResult(totalExpense);
    }
}
