﻿using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public class UserFacade(UserService userService, IncomeService incomeService, ExpenseService expenseService)
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

    public FacadeResponse<UserTransactionsDto> GetFilteredTransactions(string userId, List<int>? categoryIds,
        DateTime? dateFrom, DateTime? dateTo)
    {
        var retval = new FacadeResponse<UserTransactionsDto>();
        if (userId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");

        var incomes = incomeService.GetIncomesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var incomesDto = incomes.Select(IncomeMapping.ToIncomeDto).ToList();
        var expenses = expenseService.GetExpensesByFilters(userId, categoryIds ?? [], dateFrom, dateTo);
        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        var totalIncome = incomes.Sum(i => i.Amount);
        var totalExpense = expenses.Sum(e => e.Amount);
        var balance = totalIncome - totalExpense;

        var userTransactions = new UserTransactionsDto
        {
            UserId = userId,
            Incomes = incomesDto,
            Expenses = expensesDto,
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance
        };

        return retval.SetOk(userTransactions);
    }

    // todo statistics
}
