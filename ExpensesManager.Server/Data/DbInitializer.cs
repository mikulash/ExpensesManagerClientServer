namespace ExpensesManager.Server.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Categories.Any()) return;
        // Seed Categories
        context.Categories.AddRange(
            new Category { Name = "Food", UserId = null },
            new Category { Name = "Utilities", UserId = null },
            new Category { Name = "Salary", UserId = null }
        );

        context.SaveChanges();
    }
}
