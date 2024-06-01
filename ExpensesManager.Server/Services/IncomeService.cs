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

    public bool DeleteIncome(int incomeId)
    {
        return incomeRepository.DeleteIncome(incomeId);
    }

    public bool DeleteAllIncomes(string userId)
    {
        return incomeRepository.DeleteAllIncomes(userId);
    }
}
