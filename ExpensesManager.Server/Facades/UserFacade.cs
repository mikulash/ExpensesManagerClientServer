using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;

namespace ExpensesManager.Server.Facades;

public class UserFacade(UserService userService)
{
    public FacadeResponse<decimal> GetCurrentBalance(int userId)
    {
        var retval = new FacadeResponse<decimal>();
        if (userId == 0) return retval.SetBadRequest("User ID cannot be 0.");
        var balance = userService.GetCurrentBalance(userId);
        return retval.SetOk(balance);
    }

    public FacadeResponse<decimal> GetTotalIncome(int userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId == 0) return retval.SetBadRequest("User ID cannot be 0.");
        var totalIncome = userService.GetTotalIncome(userId);
        return retval.SetOk(totalIncome);
    }

    public FacadeResponse<decimal> GetTotalExpense(int userId)
    {
        var retval = new FacadeResponse<decimal>();

        if (userId == 0) return retval.SetBadRequest("User ID cannot be 0.");
        var totalExpense = userService.GetTotalExpense(userId);
        return retval.SetOk(totalExpense);
    }

    // todo statistics
}