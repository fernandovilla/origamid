using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Domain.Database;
using ScreenSound.Domain.Models;

namespace ScreenSound.API.Endpoints
{
    public static class GenerosExtensions
    {
        public static void AddEndpointsGeneros(this WebApplication app)
        {
            app.MapGet("/generos", ([FromServices] GeneroDAL dal) =>
            {
                return Results.Ok(dal.List());
            });

            app.MapGet("/generos/{nome}", ([FromServices] GeneroDAL dal, string nome) =>
            {
                var genero = dal.SelectBy(i => i.Nome.ToUpper().Equals(nome.ToUpper()));

                if (genero == null)
                    return Results.NotFound("Genero Musical não encontrado na base de dados");

                return Results.Ok(genero);
            });


            app.MapPost("/generos", ([FromServices] DatabaseContext context, [FromBody] GeneroRequest request) =>
            {
                try
                {
                    var dal = new GeneroDAL(context);

                    var genero = new Genero()
                    {
                        Nome = request.nome,
                    };


                    dal.Add(genero);

                    context.SaveChanges();

                    return Results.Ok();
                }
                catch (Exception)
                {
                    return Results.InternalServerError();
                }
            });

            app.MapDelete("/generos/{id}", ([FromServices] DatabaseContext context, int id) =>
            {
                var dal = new GeneroDAL(context);

                var genero = dal.SelectBy(i => i.Id == id);

                if (genero != null)
                {
                    dal.Delete(genero);

                    context.SaveChanges();

                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound("Genero Musical não encontrado");
                }

            });
        }
    }
}
