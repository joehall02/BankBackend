using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankBackend.Migrations
{
    /// <inheritdoc />
    public partial class SixthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Employees",
                newName: "Name");
        }
    }
}
