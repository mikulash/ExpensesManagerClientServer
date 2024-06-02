using ExpensesManager.Server.Data;

namespace ExpensesManager.Server.Repositories;

public class IncomeRepository(ApplicationDbContext context)
{
    public List<Income> GetAllIncomesByUser(string userId)
    {
        return context.Incomes.Where(i => i.UserId == userId).ToList();
    }

    public Income? GetIncomeById(int incomeId)
    {
        return context.Incomes.FirstOrDefault(i => i.Id == incomeId);
    }

    public bool SetIncome(Income income)
    {
        // add or update income
        var isIncomePresent = context.Incomes.Any(i => i.Id == income.Id);
        if (isIncomePresent)
            context.Incomes.Update(income);
        else
            context.Incomes.Add(income);

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
