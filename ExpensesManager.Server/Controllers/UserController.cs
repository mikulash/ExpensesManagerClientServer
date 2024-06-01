using System.Security.Claims;
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
    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized(new { Success = false, Message = "Unauthorized" });

        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return NotFound(new { Success = false, Message = "User not found" });

        var userDetails = new
        {
            user.Id,
            user.UserName,
            user.Email
        };

        return Ok(new { Success = true, User = userDetails });
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
