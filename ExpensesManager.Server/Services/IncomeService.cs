using ExpensesManager.Server.Models;
using ExpensesManager.Server.Repositories;

namespace ExpensesManager.Server.Services;

public class IncomeService(IncomeRepository incomeRepository)
{
    public List<Income> GetAllIncomesByUser(string userId)
    {
        return incomeRepository.GetAllIncomesByUser(userId);
    }

    public Income? GetIncomeById(int incomeId)
    {
        return incomeRepository.GetIncomeById(incomeId);
    }

    public bool SetIncome(Income income)
    {
        return incomeRepository.SetIncome(income);
    }

    public bool SetIncomes(List<Income> incomes)
    {
        return incomeRepository.SetIncomes(incomes);
    }

    public bool DeleteIncome(int incomeId)
    {
        return incomeRepository.DeleteIncome(incomeId);
    }

    public bool DeleteAllIncomes(string userId)
    {
        return incomeRepository.DeleteAllIncomes(userId);
    }

    public List<Income> GetIncomesByFilters(string userId, List<int> categoryIds, DateTime? startDate,
        DateTime? endDate)
    {
        return incomeRepository.GetIncomesByFilters(userId, categoryIds, startDate, endDate);
    }
}
