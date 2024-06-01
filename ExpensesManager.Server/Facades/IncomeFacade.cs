﻿using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public class IncomeFacade(IncomeService incomeService)
{
    public FacadeResponse<List<Income>> GetAllIncomesByUser(string userId)
    {
        var retval = new FacadeResponse<List<Income>>();
        var incomes = incomeService.GetAllIncomesByUser(userId);
        if (incomes.Count == 0) return retval.SetNotFound("No incomes found.");

        return retval.SetOk(incomes);

    }

    public FacadeResponse<Income> GetIncomeById(int incomeId)
    {
        var retval = new FacadeResponse<Income>();
        var income = incomeService.GetIncomeById(incomeId);
        if (income == null) return retval.SetNotFound("Income not found.");

        return retval.SetOk(income);

    }

    public FacadeResponse<bool> SetIncome(IncomeDto incomeDto)
    {
        var retval = new FacadeResponse<bool>();
        if (incomeDto.UserId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");

        var income = IncomeMapping.ToIncome(incomeDto);

        var result = incomeService.SetIncome(income);
        if (!result) return retval.SetError(500, "Failed to set income.");

        return retval.SetOk(result);
    }

    public FacadeResponse<bool> DeleteIncome(int incomeId)
    {
        var retval = new FacadeResponse<bool>();
        var result = incomeService.DeleteIncome(incomeId);
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
