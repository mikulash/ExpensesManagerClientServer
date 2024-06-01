using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class Category
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; }

    [Required] public string UserId { get; set; }

    public IdentityUser User { get; set; }
}
