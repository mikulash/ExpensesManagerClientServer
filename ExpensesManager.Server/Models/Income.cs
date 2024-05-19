using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpensesManager.Server.Models;

public class Income
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }

    public DateTime Date { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

}
