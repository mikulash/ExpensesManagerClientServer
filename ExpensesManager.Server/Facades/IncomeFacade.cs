using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public interface IIncomeFacade
{
    FacadeResponse<List<IncomeDto>> GetAllIncomesByUser(string userId);
    FacadeResponse<IncomeDto> GetIncomeById(int incomeId, string userId);
    FacadeResponse<IncomeDto> SetIncome(IncomeDto incomeDto, string userId);
    FacadeResponse<bool> DeleteIncome(int incomeId, string userId);
    FacadeResponse<bool> DeleteAllIncomes(string userId);
}

public class IncomeFacade(IIncomeService incomeService) : IIncomeFacade
{
    public FacadeResponse<List<IncomeDto>> GetAllIncomesByUser(string userId)
    {
        var retval = new FacadeResponse<List<IncomeDto>>();
        var incomes = incomeService.GetAllIncomesByUser(userId);
        if (incomes.Count == 0) return retval.SetNotFound("No incomes found.");

        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();

        return retval.SetOk(incomesDto);

    }

    public FacadeResponse<IncomeDto> GetIncomeById(int incomeId, string userId)
    {
        var retval = new FacadeResponse<IncomeDto>();
        var income = incomeService.GetIncomeById(incomeId, userId);
        if (income == null) return retval.SetNotFound("Income not found.");

        var incomeDto = IncomeMapping.ToIncomeDto(income);

        return retval.SetOk(incomeDto);

    }

    public FacadeResponse<IncomeDto> SetIncome(IncomeDto incomeDto, string userId)
    {
        var retval = new FacadeResponse<IncomeDto>();
        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");

        var income = IncomeMapping.ToIncome(incomeDto, userId);

        var result = incomeService.SetIncome(income);
        if (!result) return retval.SetError(500, "Failed to set income.");
        var retvalIncomeDto = IncomeMapping.ToIncomeDto(income);

        return retval.SetOk(retvalIncomeDto);
    }

    public FacadeResponse<bool> DeleteIncome(int incomeId, string userId)
    {
        var retval = new FacadeResponse<bool>();
        var result = incomeService.DeleteIncome(incomeId, userId);
        if (!result) return retval.SetNotFound("Failed to delete income.");

        return retval.SetOk(result);
    }

    public FacadeResponse<bool> DeleteAllIncomes(string userId)
    {
        var retval = new FacadeResponse<bool>();
        var result = incomeService.DeleteAllIncomes(userId);
        if (!result) return retval.SetNotFound("Failed to delete incomes.");

        return retval.SetOk(result);
    }
}
