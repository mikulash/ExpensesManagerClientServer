
namespace ExpensesManager.Server.Data;

public class DbInitializer
{
    public static void Initialize( ApplicationDbContext context)
    {
        context.Database.EnsureCreated();


        if (context.Categories.Any())
        {
            return;
        }
        // Seed Categories
        context.Categories.AddRange(
            new Category { Name = "Food", CategoryId = 1},
            new Category { Name = "Utilities", CategoryId = 2},
            new Category { Name = "Salary", CategoryId = 3}
        );

        context.SaveChanges();
    }


}
