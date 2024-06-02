using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Server.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        context.Database.EnsureCreated();

        if (context.Categories.Any()) return; // DB has been seeded
        // Seed user and his default Categories
        var user = new IdentityUser { UserName = "seededUser", Email = "seededUser@seed.cz" };
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

        context.SaveChanges();
    }
}
