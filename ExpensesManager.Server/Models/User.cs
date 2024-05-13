using System.ComponentModel.DataAnnotations;

namespace ExpensesManager.Server.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public string Password { get; set; }  // Store hashed passwords only

    [MaxLength(100)]
    public string Email { get; set; }
}
