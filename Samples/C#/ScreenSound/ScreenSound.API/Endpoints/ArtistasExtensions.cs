using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Domain.Database;
using ScreenSound.Domain.Models;

namespace ScreenSound.API.Endpoints
{
    public static class ArtistasExtensions
    {
        public static void AddEndpointsArtistas(this WebApplication app)
        {
            app.MapGet("/artistas", ([FromServices] ArtistaDAL dal) =>
            {
                return Results.Ok(dal.List());
            });

            app.MapGet("/artistas/{nome}", ([FromServices] ArtistaDAL dal, string nome) =>
            {
                var artista = dal.SelectBy(i => i.Nome.ToUpper().Equals(nome.ToUpper()));

                if (artista == null)
                    return Results.NotFound("Artista não encontrado na base de dados");

                return Results.Ok(artista);
            });

            app.MapPost("/artistas", ([FromServices] DatabaseContext context, [FromBody] ArtistaRequest request) =>
            {
                try
                {
                    var dal = new ArtistaDAL(context);

                    var novoArtista = new Artista()
                    {
                        Nome = request.nome,
                        Bio = request.bio,
                    };


                    dal.Add(novoArtista);

                    context.SaveChanges();

                    return Results.Ok();
                }
                catch (Exception)
                {
                    return Results.InternalServerError();
                }
            });

            app.MapDelete("/artistas/{id}", ([FromServices] DatabaseContext context, int id) =>
            {
                var dal = new ArtistaDAL(context);

                var art = dal.SelectBy(i => i.Id == id);

                if (art != null)
                {
                    dal.Delete(art);

                    context.SaveChanges();

                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound("Artista não encontrado");
                }

            });
        }
    }
}
