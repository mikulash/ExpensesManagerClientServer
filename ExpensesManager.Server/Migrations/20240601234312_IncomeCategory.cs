using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class IncomeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Incomes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Incomes");
        }
    }
}
