using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Domain.Database;
using ScreenSound.Domain.Models;
using ScreenSound.API.Endpoints;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.AddEndpointsArtistas();

app.AddEndpointsMusicas();

app.AddEndpointsGeneros();

app.UseSwagger();

app.UseSwaggerUI();



app.Run();