using BlazorWebApp.Client.Pages;
using BlazorWebApp.Components;
using BlazorWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

/* Três maneitas de incluir injeção dependência */
//  builder.Services.AddTransient();    //sempre uma nova instância
//  builder.Services.AddSingleton();    //uma única instância
//  builder.Services.AddScoped();       //nova instância em cada request

//builder.Services.AddTransient<NumeroAleatorio>();
builder.Services.AddScoped<NumeroAleatorio>();
//builder.Services.AddSingleton<NumeroAleatorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebApp.Client._Imports).Assembly);

app.Run();
