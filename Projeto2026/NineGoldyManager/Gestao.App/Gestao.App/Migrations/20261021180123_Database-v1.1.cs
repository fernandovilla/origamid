using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.App.Migrations
{
    /// <inheritdoc />
    public partial class Databasev11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Customers");
        }
    }
}
