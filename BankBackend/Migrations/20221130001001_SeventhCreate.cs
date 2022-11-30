using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankBackend.Migrations
{
    /// <inheritdoc />
    public partial class SeventhCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Employees",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employees",
                newName: "UserName");
        }
    }
}
