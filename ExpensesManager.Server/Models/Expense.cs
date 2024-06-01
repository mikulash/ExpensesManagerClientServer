using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExpensesManager.Server.Models;

public class Expense
{
    [Key] public int Id { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [Required] [MaxLength(255)] public string Description { get; set; }

    public DateTime Date { get; set; }

    [Required] public int CategoryId { get; set; }

    public Category Category { get; set; }
    [Required] public string UserId { get; set; }

    public IdentityUser User { get; set; }
}
