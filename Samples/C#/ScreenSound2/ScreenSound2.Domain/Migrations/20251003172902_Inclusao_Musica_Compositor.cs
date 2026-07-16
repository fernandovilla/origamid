using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Inclusao_Musica_Compositor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Compositor",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Compositor",
                table: "Musicas");
        }
    }
}
