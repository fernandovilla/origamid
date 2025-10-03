using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", 
                new string[] { "Nome", "Bio", "FotoPerfil" }, 
                new object[] { "Djavan", "É um cantor, compositor, arranjador, produtor musical, empresário, violonista e ex-jogador de futebol", "https://upload.wikimedia.org/wikipedia/commons/5/54/Djavan_%28cropped%29.jpg" });

            migrationBuilder.InsertData("Artistas",
                new string[] { "Nome", "Bio", "FotoPerfil" },
                new object[] { "Jota Quest", "É uma banda brasileira de pop rock formada em 1993, em Belo Horizonte, Minas Gerais. A banda se consolidou no cenário nacional com uma sonoridade que mistura pop, rock e elementos de soul music.", "https://i.em.com.br/Zevn6U2ucgyQQCO9lSWwQjlU2Lo=/1200x900/smart/imgsapp.em.com.br/app/noticia_127983242361/2022/08/27/1389337/jota-quest_1_57041.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MUSICAS;");
            migrationBuilder.Sql("DELETE FROM ARTISTAS;");            
        }
    }
}
