using ExpensesManager.Server.Data;
using ExpensesManager.Server.Models;

namespace ExpensesManager.Server.Repositories;

public interface ICategoryRepository
{
    List<Category> GetAllCategoriesByUser(string userId, bool includeDefaultCategories = true);
    Category? GetCategoryById(int categoryId, string userId);
    bool SetCategory(Category category);
    bool SetCategories(List<Category> categories);
    bool DeleteCategory(int categoryId, string userId);
    bool DeleteAllCategories(string userId);
}

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    private List<Category> GetAllDefaultCategories()
    {
        return context.Categories.Where(c => c.UserId == "").ToList();
    }

    public List<Category> GetAllCategoriesByUser(string userId, bool includeDefaultCategories = true)
    {
        var categories = context.Categories.Where(c => c.UserId == userId).ToList();
        if (!includeDefaultCategories) return categories;

        var defaultCategories = GetAllDefaultCategories();
        categories.AddRange(defaultCategories);

        return categories;
    }

    public Category? GetCategoryById(int categoryId, string userId)
    {
        return context.Categories.FirstOrDefault(c => c.Id == categoryId && c.UserId == userId);
    }

    /**
     * Add or update category
     * @param category object
     * @return bool True if changes saved successfully, false otherwise
     */
    public bool SetCategory(Category category)
    {
        var isCategoryPresent = context.Categories.Any(c => c.Id == category.Id);
        if (isCategoryPresent)
            context.Categories.Update(category);
        else
            context.Categories.Add(category);

        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool SetCategories(List<Category> categories)
    {

        foreach (var category in categories)
        {
            var isSetSuccessfully = SetCategory(category);
            if (!isSetSuccessfully) return false;
        }

        return true;
    }

    public bool DeleteCategory(int categoryId, string userId)
    {
        var category = context.Categories.FirstOrDefault(c => c.Id == categoryId && c.UserId == userId);
        if (category == null) return false;

        context.Categories.Remove(category);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }

    public bool DeleteAllCategories(string userId)
    {
        var categories = context.Categories.Where(c => c.UserId == userId).ToList();
        if (categories.Count == 0) return false;

        context.Categories.RemoveRange(categories);
        var changesSaved = context.SaveChanges() > 0;
        return changesSaved;
    }
}
