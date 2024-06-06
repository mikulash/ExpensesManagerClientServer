namespace ExpensesManager.Server.DTOs;

public class IncomeDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public int CategoryId { get; set; }
}
