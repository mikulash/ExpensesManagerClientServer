using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Server.Facades;

public class CategoryFacade(CategoryService categoryService)
{
    public FacadeResponse<List<Category>> GetAllDefaultCategories()
    {
        var retval = new FacadeResponse<List<Category>>();
        var categories = categoryService.GetAllDefaultCategories();
        if (categories.Count == 0) return retval.SetNotFound("No default categories found.");

        return retval.SetOk(categories);

    }

    public FacadeResponse<List<Category>> GetAllCategoriesByUser(string userId)
    {
        var retval = new FacadeResponse<List<Category>>();
        var categories = categoryService.GetAllCategoriesByUser(userId);
        if (categories.Count == 0) return retval.SetNotFound("No default categories found.");

        return retval.SetOk(categories);
    }

    public FacadeResponse<Category> GetCategoryById(int categoryId)
    {
        var retval = new FacadeResponse<Category>();
        var category = categoryService.GetCategoryById(categoryId);
        if (category == null) return retval.SetNotFound("Category not found.");
        return retval.SetOk(category);
    }

    public FacadeResponse<bool> SetCategory(CategoryDto categoryDto)
    {
        var retval = new FacadeResponse<bool>();

        if (categoryDto.UserId.IsNullOrEmpty()) return retval.SetBadRequest("User ID cannot be 0.");

        var category = CategoryMapping.ToCategory(categoryDto);

        var isSuccess = categoryService.SetCategory(category);
        if (!isSuccess) return retval.SetServerError("Error saving category.");
        return retval.SetOk(isSuccess);
    }

    public FacadeResponse<bool> DeleteCategory(int categoryId)
    {
        var retval = new FacadeResponse<bool>();
        var isDeletingSuccess = categoryService.DeleteCategory(categoryId);
        if (!isDeletingSuccess) return retval.SetNotFound("Category not found.");
        return retval.SetOk(isDeletingSuccess);
    }

    public FacadeResponse<bool> DeleteAllCategories(string userId)
    {
        var retval = new FacadeResponse<bool>();
        var isDeletingSuccess = categoryService.DeleteAllCategories(userId);
        if (!isDeletingSuccess) return retval.SetNotFound("No categories found.");
        return retval.SetOk(isDeletingSuccess);
    }
}
