using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ninegoldy.Migrations
{
    /// <inheritdoc />
    public partial class Database10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDTOUserDTO");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Companies",
                newName: "CreatedAt");

            migrationBuilder.CreateTable(
                name: "UserCompany",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany", x => new { x.CompanyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCompany_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompany_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_UserId",
                table: "UserCompany",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCompany");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Companies",
                newName: "CreateAt");

            migrationBuilder.CreateTable(
                name: "CompanyDTOUserDTO",
                columns: table => new
                {
                    EmpresasId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuariosId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDTOUserDTO", x => new { x.EmpresasId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_CompanyDTOUserDTO_Companies_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyDTOUserDTO_Users_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDTOUserDTO_UsuariosId",
                table: "CompanyDTOUserDTO",
                column: "UsuariosId");
        }
    }
}
