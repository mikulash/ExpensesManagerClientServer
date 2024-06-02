using ExpensesManager.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Server.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        context.Database.EnsureCreated();

        if (context.Categories.Any()) return;
        // Seed user and his default Categories

        var user = new IdentityUser { UserName = "seededUser", Email = "seededUser@seed.cz" };
        var result = userManager.CreateAsync(user, "SeededUser123!").Result;

        if (!result.Succeeded) throw new DbUpdateException("Failed to create seeded user.");
        var categories = CategoryService.CreateDefaultCategories(user.Id);

        context.Categories.AddRange(categories);

        context.SaveChanges();
    }
}
