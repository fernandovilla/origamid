using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

            app.MapGet("/artistas/{id}", ([FromServices] ArtistaDAL dal, int id) =>
            {
                var artista = dal.SelectBy(i => i.Id == id);

                if (artista == null)
                    return Results.NotFound("Artista não encontrado na base de dados");

                return Results.Ok(artista);
            });

            //app.MapGet("/artistas/{nome}", ([FromServices] ArtistaDAL dal, string nome) =>
            //{
            //    var artista = dal.SelectBy(i => i.Nome.ToUpper().Equals(nome.ToUpper()));

            //    if (artista == null)
            //        return Results.NotFound("Artista não encontrado na base de dados");

            //    return Results.Ok(artista);
            //});

            app.MapPost("/artistas", async ([FromServices] IHostEnvironment environment, [FromServices] DatabaseContext context, [FromBody] ArtistaRequest request) =>
            {
                try
                {
                    var dal = new ArtistaDAL(context);


                    var novoArtista = new Artista()
                    {
                        Nome = request.nome.Trim(),
                        Bio = request.bio?.Trim()
                    };

                    dal.Add(novoArtista);

                    context.SaveChanges();

                    if (!string.IsNullOrEmpty(request.fotoPerfil))
                    {
                        var fotoPerfil = $"{novoArtista.Id}_{DateTime.Now.ToString("ddMMyyyyhhmmss")}.jpg";
                        var path = Path.Combine(environment.ContentRootPath, "wwwroot\\FotosPerfil", fotoPerfil);

                        using (var ms = new MemoryStream(Convert.FromBase64String(request.fotoPerfil)))
                        using (var fs = new FileStream(path, FileMode.Create))
                        {
                            await ms.CopyToAsync(fs);
                            await fs.FlushAsync();
                            fs.Close();
                        }

                        novoArtista.FotoPerfil = fotoPerfil;
                        dal.Update(novoArtista);
                        context.SaveChanges();
                    }



                    return Results.Ok();
                }
                catch (Exception)
                {
                    return Results.InternalServerError();
                }
            });

            app.MapPut("/artistas", ([FromServices] DatabaseContext context, [FromBody] ArtistaRequestEdit request) =>
            {
                var dal = new ArtistaDAL(context);

                var art = dal.SelectBy(i => i.Id == request.id);

                if (art != null)
                {
                    art.Nome = request.nome;
                    art.Bio = request.bio;
                    art.FotoPerfil = request.fotoPerfil;

                    dal.Update(art);

                    context.SaveChanges();

                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound("Artista não encontrado");
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
