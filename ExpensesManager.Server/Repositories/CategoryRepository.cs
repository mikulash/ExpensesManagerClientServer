using ExpensesManager.Server.Data;

namespace ExpensesManager.Server.Repositories;

public class CategoryRepository(ApplicationDbContext context)
{
    public List<Category> GetAllDefaultCategories()
    {
        return context.Categories.Where(c => c.UserId == 0).ToList();
    }

    public List<Category> GetAllCategoriesByUser(int userId, bool includeDefaultCategories = true)
    {
        var categories = context.Categories.Where(c => c.UserId == userId).ToList();
        if (!includeDefaultCategories) return categories;

        var defaultCategories = context.Categories.Where(c => c.UserId == 0).ToList();
        categories.AddRange(defaultCategories);

        return categories;
    }

    public Category? GetCategoryById(int categoryId)
    {
        return context.Categories.FirstOrDefault(c => c.Id == categoryId);
    }

    public bool SetCategory(Category category)
    {
        // add or update category
        var isCategoryPresent = context.Categories.Any(c => c.Id == category.Id);
        if (isCategoryPresent)
            context.Categories.Update(category);
        else
            context.Categories.Add(category);

        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool DeleteCategory(int categoryId)
    {
        var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
        if (category == null) return false;

        context.Categories.Remove(category);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool DeleteAllCategories(int userId)
    {
        var categories = context.Categories.Where(c => c.UserId == userId).ToList();
        if (categories.Count == 0) return false;

        context.Categories.RemoveRange(categories);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }
}