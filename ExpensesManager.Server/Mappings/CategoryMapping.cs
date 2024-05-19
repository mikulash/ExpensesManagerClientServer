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
            UserId = category.UserId
        };
    }

    public static Category ToCategory(CategoryDto categoryDto)
    {
        return new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            UserId = categoryDto.UserId
        };
    }
}