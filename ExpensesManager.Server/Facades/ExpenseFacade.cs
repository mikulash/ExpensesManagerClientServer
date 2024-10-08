﻿using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public interface IExpenseFacade
{
    FacadeResponse<List<ExpenseDto>> GetAllExpensesByUser(string userId);
    FacadeResponse<ExpenseDto> GetExpenseById(int expenseId, string userId);
    FacadeResponse<ExpenseDto> SetExpense(ExpenseDto expenseDto, string userId);
    FacadeResponse<bool> DeleteExpense(int expenseId, string userId);
    FacadeResponse<bool> DeleteAllExpenses(string userId);
    FacadeResponse<List<ExpenseDto>> GetExpensesByCategory(string userId, int categoryId);
    FacadeResponse<List<ExpenseDto>> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate);
    FacadeResponse<List<ExpenseDto>> GetExpensesByAmountRange(string userId, decimal minAmount, decimal maxAmount);
}

public class ExpenseFacade(IExpenseService expenseService) : IExpenseFacade
{
    public FacadeResponse<List<ExpenseDto>> GetAllExpensesByUser(string userId)
    {
        var retval = new FacadeResponse<List<ExpenseDto>>();
        var expenses = expenseService.GetAllExpensesByUser(userId);
        if (expenses.Count == 0) return retval.SetNotFound("No expenses found.");

        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        return retval.SetOk(expensesDto);
    }

    public FacadeResponse<ExpenseDto> GetExpenseById(int expenseId, string userId)
    {
        var retval = new FacadeResponse<ExpenseDto>();
        var expense = expenseService.GetExpenseById(expenseId, userId);
        if (expense == null) return retval.SetNotFound("Expense not found.");

        var expenseDto = ExpenseMapping.ToExpenseDto(expense);

        return retval.SetOk(expenseDto);
    }

    public FacadeResponse<ExpenseDto> SetExpense(ExpenseDto expenseDto, string userId)
    {
        var retval = new FacadeResponse<ExpenseDto>();

        if (userId.IsNullOrEmpty()) return retval.SetUnauthorized("User ID cannot be 0.");

        var expense = ExpenseMapping.ToExpense(expenseDto, userId);
        var result = expenseService.SetExpense(expense);
        if (!result) return retval.SetError(500, "Failed to set expense.");
        var retvalExpenseDto = ExpenseMapping.ToExpenseDto(expense);

        return retval.SetOk(retvalExpenseDto);
    }

    public FacadeResponse<bool> DeleteExpense(int expenseId, string userId)
    {
        var retval = new FacadeResponse<bool>();
        var result = expenseService.DeleteExpense(expenseId, userId);
        if (!result) return retval.SetNotFound("Failed to delete expense.");

        return retval.SetOk(result);
    }

    public FacadeResponse<bool> DeleteAllExpenses(string userId)
    {
        var retval = new FacadeResponse<bool>();
        var result = expenseService.DeleteAllExpenses(userId);
        if (!result) return retval.SetError(500, "Failed to delete all expenses.");

        return retval.SetOk(result);
    }

    public FacadeResponse<List<ExpenseDto>> GetExpensesByCategory(string userId, int categoryId)
    {
        var retval = new FacadeResponse<List<ExpenseDto>>();
        var expenses = expenseService.GetExpensesByCategory(userId, categoryId);
        if (expenses.Count == 0) return retval.SetNotFound("No expenses found for the specified category.");

        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        return retval.SetOk(expensesDto);
    }

    public FacadeResponse<List<ExpenseDto>> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate)
    {
        var retval = new FacadeResponse<List<ExpenseDto>>();
        var expenses = expenseService.GetExpensesByDateRange(userId, startDate, endDate);
        if (expenses.Count == 0) return retval.SetNotFound("No expenses found in the specified date range.");

        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        return retval.SetOk(expensesDto);
    }

    public FacadeResponse<List<ExpenseDto>> GetExpensesByAmountRange(string userId, decimal minAmount,
        decimal maxAmount)
    {
        var retval = new FacadeResponse<List<ExpenseDto>>();
        var expenses = expenseService.GetExpensesByAmountRange(userId, minAmount, maxAmount);
        if (expenses.Count == 0) return retval.SetNotFound("No expenses found in the specified amount range.");

        var expensesDto = expenses.Select(ExpenseMapping.ToExpenseDto).ToList();

        return retval.SetOk(expensesDto);
    }
}
