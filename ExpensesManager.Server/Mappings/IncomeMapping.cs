using ExpensesManager.Server.DTOs;

namespace ExpensesManager.Server.Mappings;

public class IncomeMapping
{
    public static IncomeDto ToIncomeDto(Income income)
    {
        return new IncomeDto
        {
            Id = income.Id,
            Amount = income.Amount,
            Description = income.Description,
            Date = income.Date,
            UserId = income.UserId
        };
    }

    public static Income ToIncome(IncomeDto incomeDto)
    {
        return new Income
        {
            Id = incomeDto.Id,
            Amount = incomeDto.Amount,
            Description = incomeDto.Description,
            Date = incomeDto.Date,
            UserId = incomeDto.UserId
        };
    }
}