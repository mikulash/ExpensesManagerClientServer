using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(UserFacade userFacade, UserManager<IdentityUser> userManager) : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserDto>> GetUser()
    {
        var userId = GetUserId();
        if (userId.IsNullOrEmpty()) return Unauthorized(new { Success = false, Message = "Unauthorized" });

        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return NotFound(new { Success = false, Message = "User not found" });

        var userResponse = new UserDto
        {
            UserId = userId, Username = user.UserName, Email = user.Email
        };

        return Ok(userResponse);
    }


    [HttpGet("Balance")]
    public ActionResult<decimal> GetCurrentUserBalance()
    {
        var userId = GetUserId();
        if (userId.IsNullOrEmpty()) return Unauthorized(new { Success = false, Message = "Unauthorized" });

        var retval = userFacade.GetCurrentBalance(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("TotalIncome")]
    public ActionResult<decimal> GetTotalIncome(string userId)
    {
        var totalIncome = userFacade.GetTotalIncome(userId);
        return FacadeResponseToActionResult(totalIncome);
    }

    [HttpGet("TotalExpense")]
    public ActionResult<decimal> GetTotalExpense(string userId)
    {
        var totalExpense = userFacade.GetTotalExpense(userId);
        return FacadeResponseToActionResult(totalExpense);
    }
}
