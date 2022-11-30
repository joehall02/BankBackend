using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankBackend.Migrations
{
    /// <inheritdoc />
    public partial class TenthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Overdraft",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overdraft",
                table: "Accounts");
        }
    }
}
