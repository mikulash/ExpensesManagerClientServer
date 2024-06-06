using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Mappings;

public static class IncomeMapping
{
    public static IncomeDto ToIncomeDto(Income income)
    {
        return new IncomeDto
        {
            Id = income.Id,
            Amount = income.Amount,
            Description = income.Description,
            Date = income.Date,
            CategoryId = income.CategoryId
        };
    }

    public static Income ToIncome(IncomeDto incomeDto, string userId)
    {
        return new Income
        {
            Id = incomeDto.Id,
            Amount = incomeDto.Amount,
            Description = incomeDto.Description,
            Date = incomeDto.Date,
            UserId = userId,
            CategoryId = incomeDto.CategoryId
        };
    }
}
