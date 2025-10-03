using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ScreenSound.API.Requests;
using ScreenSound.Domain.Database;
using ScreenSound.Domain.Models;
using System.Net.NetworkInformation;

namespace ScreenSound.API.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndpointsMusicas(this WebApplication app)
        {
            app.MapGet("/musicas", ([FromServices] MusicaDAL dal) =>
            {
                return Results.Ok(dal.List());
            });

            app.MapGet("/musicas/{nome}", ([FromServices] MusicaDAL dal, string nome) =>
            {
                var artista = dal.SelectBy(i => i.Nome.ToUpper().Equals(nome.ToUpper()));

                if (artista == null)
                    return Results.NotFound("Música não encontrada na base de dados");

                return Results.Ok(artista);
            });

            app.MapPost("/musicas", ([FromServices] DatabaseContext context, [FromBody] MusicaRequest request) =>
            {
                try
                {
                    var dal = new MusicaDAL(context);

                    var musica = new Musica
                    {
                        Nome = request.nome,
                        AnoLancamento = request.anoLancamento,
                        ArtistaId = request.artistaId,
                        Generos = GeneroRequestConverter(new GeneroDAL(context), request.generos).ToList()
                    };

                    dal.Add(musica);

                    context.SaveChanges();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError();
                }
            });

            app.MapDelete("/musicas/{id}", ([FromServices] DatabaseContext context, int id) =>
            {
                var dal = new MusicaDAL(context);

                var art = dal.SelectBy(i => i.Id == id);

                if (art != null)
                {
                    dal.Delete(art);

                    context.SaveChanges();

                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound("Musica não encontrada");
                }

            });
        }

        private static IEnumerable<Genero> GeneroRequestConverter(GeneroDAL generodal, ICollection<GeneroRequest> generos)
        {
            foreach (var i in generos)
            {
                var gen = generodal.SelectBy(i => i.Nome.ToUpper().Equals(i.Nome.ToUpper()));

                if (gen != null)
                    yield return gen;

                yield return new Genero() { Nome = i.nome };
            }
        }
    }
}
