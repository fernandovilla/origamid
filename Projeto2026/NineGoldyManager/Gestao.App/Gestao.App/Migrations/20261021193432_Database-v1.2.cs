using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.App.Migrations
{
    /// <inheritdoc />
    public partial class Databasev12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellPhoneNumber",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhoneNumber",
                table: "Customers");
        }
    }
}
