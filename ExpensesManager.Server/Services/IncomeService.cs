using ExpensesManager.Server.Models;
using ExpensesManager.Server.Repositories;

namespace ExpensesManager.Server.Services;

public interface IIncomeService
{
    List<Income> GetAllIncomesByUser(string userId);
    Income? GetIncomeById(int incomeId);
    bool SetIncome(Income income);
    bool SetIncomes(List<Income> incomes);
    bool DeleteIncome(int incomeId);
    bool DeleteAllIncomes(string userId);
    List<Income> GetIncomesByFilters(string userId, List<int> categoryIds, DateTime? startDate, DateTime? endDate);
}

public class IncomeService(IIncomeRepository incomeRepository) : IIncomeService
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
