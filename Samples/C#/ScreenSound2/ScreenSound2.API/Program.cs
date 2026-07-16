using System.Text.Json.Serialization;
using ScreenSound.Domain.Database;
using ScreenSound.Domain.Models;
using ScreenSound.API.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        builder.Services.AddDbContext<DatabaseContext>();
        builder.Services.AddTransient<ArtistaDAL>();
        builder.Services.AddTransient<MusicaDAL>();
        builder.Services.AddTransient<GeneroDAL>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        ));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        app.AddEndpointsArtistas();

        app.AddEndpointsMusicas();

        app.AddEndpointsGeneros();

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseCors("MyPolicy");

        //app.UseCors(opt =>
        //{
        //    opt.
        //        AllowAnyOrigin()
        //        .AllowAnyMethod()
        //        .AllowAnyHeader();
        //});

        app.UseStaticFiles();

        app.Run();
    }
}