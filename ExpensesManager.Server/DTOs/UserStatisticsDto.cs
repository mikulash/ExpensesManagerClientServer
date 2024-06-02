namespace ExpensesManager.Server.DTOs;

public class UserStatisticsDto
{
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }

    public List<AggregatedTotalDto> IncomePerMonth { get; set; }
    public List<AggregatedTotalDto> ExpensePerMonth { get; set; }
    public List<AggregatedTotalDto> BalancePerMonth { get; set; }

    public List<AggregatedTotalDto> IncomePerCategory { get; set; }
    public List<AggregatedTotalDto> ExpensePerCategory { get; set; }
    public List<AggregatedTotalDto> BalancePerCategory { get; set; }
}
