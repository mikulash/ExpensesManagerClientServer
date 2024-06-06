namespace ExpensesManager.Server.DTOs;

public class UserImportDataDto
{
    public List<IncomeDto> Incomes { get; set; }
    public List<ExpenseDto> Expenses { get; set; }
    public List<CategoryDto> Categories { get; set; }
}