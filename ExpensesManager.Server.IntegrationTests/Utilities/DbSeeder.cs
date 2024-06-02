using ExpensesManager.Server.Data;
using Microsoft.AspNetCore.Identity;

namespace ExpensesManager.Server.IntegrationTests.Utilities;

public class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Categories.Any()) return; // Database has already been seeded

        var categories = new List<Category>
        {
            new() { Name = "Food" },
            new() { Name = "Utilities" },
            new() { Name = "Salary" }
        };

        context.Categories.AddRange(categories);

        var users = new List<IdentityUser>
        {
            new() { UserName = "testuser", Email = "testuser@example.com" }
        };

        context.Users.AddRange(users);

        context.SaveChanges();
    }


    private static List<IdentityUser> CreateUsers()
    {
        return new List<IdentityUser>
        {
            new() { UserName = "firstUser", Email = "firstUser@example.com" },
            new() { UserName = "secondUser", Email = "secondUser@example.com" }
        };
    }

    private static List<Category> CreateCategories(string userId)
    {
        return new List<Category>
        {
            new() { Name = "Food", UserId = userId },
            new() { Name = "Utilities", UserId = userId },
            new() { Name = "Salary", UserId = userId }
        };
    }
}
