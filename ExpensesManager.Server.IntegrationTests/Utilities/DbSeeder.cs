using ExpensesManager.Server.Data;
using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Server.IntegrationTests.Utilities;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {

        var users = MockDataFactory.CreateUsers();

        foreach (var user in users)
        {
            var result = userManager.CreateAsync(user, MockDataFactory.password).Result;
            if (!result.Succeeded) throw new DbUpdateException("Failed to create seeded user.");

            var categories = CategoryService.CreateDefaultCategories(user.Id);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            categories = context.Categories.Where(c => c.UserId == user.Id).ToList();

            var incomes = MockDataFactory.CreateIncomes(user.Id, categories[2].Id);
            var expenses = MockDataFactory.CreateExpenses(user.Id, categories[0].Id);

            context.SaveChanges();
            context.Incomes.AddRange(incomes);
            context.Expenses.AddRange(expenses);
        }

        context.SaveChanges();
    }
}
