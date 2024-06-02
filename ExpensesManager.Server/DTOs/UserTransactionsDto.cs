namespace ExpensesManager.Server.DTOs;

public class UserTransactionsDto
{
    public string UserId { get; set; }
    public List<IncomeDto> Incomes { get; set; }
    public List<ExpenseDto> Expenses { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }
}
