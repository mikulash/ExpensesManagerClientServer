using ExpensesManager.Server.Data;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Repositories;

public interface IIncomeRepository
{
    List<Income> GetAllIncomesByUser(string userId);
    Income? GetIncomeById(int incomeId);
    bool SetIncome(Income income);
    bool SetIncomes(List<Income> incomes);
    bool DeleteIncome(int incomeId);
    bool DeleteAllIncomes(string userId);
    List<Income> GetIncomesByFilters(string userId, List<int> categoryIds, DateTime? startDate, DateTime? endDate);
}

public class IncomeRepository(ApplicationDbContext context) : IIncomeRepository
{
    public List<Income> GetAllIncomesByUser(string userId)
    {
        return context.Incomes.Where(i => i.UserId == userId).ToList();
    }

    public Income? GetIncomeById(int incomeId)
    {
        return context.Incomes.FirstOrDefault(i => i.Id == incomeId);
    }

    /**
     * Add or update income
     * @param income object
     * @return bool True if changes saved successfully, false otherwise
     */
    public bool SetIncome(Income income)
    {
        var isIncomePresent = context.Incomes.Any(i => i.Id == income.Id);
        if (isIncomePresent)
            context.Incomes.Update(income);
        else
            context.Incomes.Add(income);

        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool SetIncomes(List<Income> incomes)
    {
        foreach (var income in incomes) SetIncome(income);

        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool DeleteIncome(int incomeId)
    {
        var income = context.Incomes.FirstOrDefault(i => i.Id == incomeId);
        if (income == null) return false;

        context.Incomes.Remove(income);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool DeleteAllIncomes(string userId)
    {
        var incomes = context.Incomes.Where(i => i.UserId == userId).ToList();
        context.Incomes.RemoveRange(incomes);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public List<Income> GetIncomesByFilters(string userId, List<int> categoryIds, DateTime? startDate,
        DateTime? endDate)
    {
        var incomes = context.Incomes.Where(i => i.UserId == userId).ToList();
        if (categoryIds.Count > 0)
            incomes = incomes.Where(i => categoryIds.Contains(i.CategoryId)).ToList();
        if (startDate != null)
            incomes = incomes.Where(i => i.Date >= startDate).ToList();
        if (endDate != null)
            incomes = incomes.Where(i => i.Date <= endDate).ToList();

        return incomes;
    }
}
