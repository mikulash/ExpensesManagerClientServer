using ExpensesManager.Server.Repositories;

namespace ExpensesManager.Server.Services;

public class CategoryService(CategoryRepository categoryRepository)
{
    public List<Category> GetAllDefaultCategories()
    {
        return categoryRepository.GetAllDefaultCategories();
    }

    public List<Category> GetAllCategoriesByUser(int userId)
    {
        return categoryRepository.GetAllCategoriesByUser(userId);
    }

    public Category? GetCategoryById(int categoryId)
    {
        return categoryRepository.GetCategoryById(categoryId);
    }

    public bool SetCategory(Category category)
    {
        return categoryRepository.SetCategory(category);
    }

    public bool DeleteCategory(int categoryId)
    {
        return categoryRepository.DeleteCategory(categoryId);
    }

    public bool DeleteAllCategories(int userId)
    {
        return categoryRepository.DeleteAllCategories(userId);
    }
}
