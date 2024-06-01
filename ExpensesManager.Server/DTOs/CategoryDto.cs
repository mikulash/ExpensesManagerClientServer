using System.ComponentModel.DataAnnotations;

namespace ExpensesManager.Server.DTOs;

public class CategoryDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    public string UserId { get; set; }
}
