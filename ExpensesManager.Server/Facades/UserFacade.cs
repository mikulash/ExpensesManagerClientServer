using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public class UserFacade(UserService userService)
{
    public FacadeResponse<decimal> GetCurrentBalance(string userId)
    {
        var retval = new FacadeResponse<decimal>();
        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var balance = userService.GetCurrentBalance(userId);
        return retval.SetOk(balance);
    }

    public FacadeResponse<decimal> GetTotalIncome(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var totalIncome = userService.GetTotalIncome(userId);
        return retval.SetOk(totalIncome);
    }

    public FacadeResponse<decimal> GetTotalExpense(string userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var totalExpense = userService.GetTotalExpense(userId);
        return retval.SetOk(totalExpense);
    }


    public FacadeResponse<UserDto> GetUser(string userId)
    {
        var retval = new FacadeResponse<UserDto>();
        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");
        var user = userService.GetUser(userId);
        return retval.SetOk(user);
    }
    // todo statistics
}
