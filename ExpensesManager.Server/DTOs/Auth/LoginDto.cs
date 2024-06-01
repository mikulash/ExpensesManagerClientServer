using System.ComponentModel.DataAnnotations;

namespace ExpensesManager.Server.DTOs.Auth;

public class LoginDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
