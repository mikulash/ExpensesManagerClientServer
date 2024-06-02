using ExpensesManager.Server.Data;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Server.IntegrationTests.Utilities;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {

        var users = new List<IdentityUser>
        {
            new() { UserName = "firstUser", Email = "firstUser@example.com" },
            new() { UserName = "secondUser", Email = "secondUser@example.com" }
        };

        foreach (var user in users)
        {
            var result = userManager.CreateAsync(user, "SeededUser123!").Result;
            if (!result.Succeeded) throw new DbUpdateException("Failed to create seeded user.");

            var categories = CategoryService.CreateDefaultCategories(user.Id);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            categories = context.Categories.Where(c => c.UserId == user.Id).ToList();

            var incomes = new List<Income>
            {
                new()
                {
                    Amount = 1000, CategoryId = categories[2].Id, Date = DateTime.Now, UserId = user.Id,
                    Description = "Salary"
                },
                new()
                {
                    Amount = 2000, CategoryId = categories[2].Id, Date = DateTime.Now, UserId = user.Id,
                    Description = "Salary"
                }
            };

            var expenses = new List<Expense>
            {
                new()
                {
                    Amount = 100, CategoryId = categories[0].Id, Date = DateTime.Now, UserId = user.Id,
                    Description = "Bread"
                },
                new()
                {
                    Amount = 200, CategoryId = categories[0].Id, Date = DateTime.Now, UserId = user.Id,
                    Description = "Vegetables"
                }
            };

            context.SaveChanges();
            context.Incomes.AddRange(incomes);
            context.Expenses.AddRange(expenses);
        }

        context.SaveChanges();
    }
}
