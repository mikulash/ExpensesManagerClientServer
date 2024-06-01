using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Mappings;
using ExpensesManager.Server.Models;
using ExpensesManager.Server.Services;

namespace ExpensesManager.Server.Facades;

public class CategoryFacade(CategoryService categoryService)
{
    public FacadeResponse<List<CategoryDto>> GetAllCategoriesByUser(string userId)
    {
        var retval = new FacadeResponse<List<CategoryDto>>();
        var categories = categoryService.GetAllCategoriesByUser(userId);
        if (categories.Count == 0) return retval.SetNotFound("No default categories found.");

        var categoriesDto = categories.Select(CategoryMapping.ToCategoryDto).ToList();
        return retval.SetOk(categoriesDto);
    }

    public FacadeResponse<CategoryDto> GetCategoryById(int categoryId, string userId)
    {
        var retval = new FacadeResponse<CategoryDto>();
        var category = categoryService.GetCategoryById(categoryId, userId);

        if (category == null) return retval.SetNotFound("Category not found.");

        if (category.UserId != userId) return retval.SetForbidden("You are not allowed to access this category.");

        var categoryDto = CategoryMapping.ToCategoryDto(category);

        return retval.SetOk(categoryDto);
    }

    public FacadeResponse<CategoryDto> SetCategory(CategoryDto categoryDto, string userId)
    {
        var retval = new FacadeResponse<CategoryDto>();

        var category = CategoryMapping.ToCategory(categoryDto, userId);

        var isSuccess = categoryService.SetCategory(category);
        if (!isSuccess) return retval.SetServerError("Error saving category.");

        return retval.SetOk(categoryDto);
    }

    public FacadeResponse<bool> DeleteCategory(int categoryId, string userId)
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
