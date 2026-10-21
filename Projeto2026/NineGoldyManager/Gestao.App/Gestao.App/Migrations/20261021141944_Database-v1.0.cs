using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.App.Migrations
{
    /// <inheritdoc />
    public partial class Databasev10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPessoa",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Customers");
        }
    }
}
