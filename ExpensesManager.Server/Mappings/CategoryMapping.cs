using ExpensesManager.Server.DTOs;

namespace ExpensesManager.Server.Mappings;

public class CategoryMapping
{
    public static CategoryDto ToCategoryDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
        };
    }

    public static Category ToCategory(CategoryDto categoryDto, string userId)
    {
        return new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            UserId = userId
        };
    }
}
