using JwtAuthentication.Lib.Models;
using JwtAuthentication.Web.Client.Services;
using JwtAuthentication.Web.Components;
using JwtAuthentication.Web.Handlers;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<TokenResponseDto>();
builder.Services.AddScoped<AuthenticationHandler>();

// Registra a API de Autenticação (separada para evitar loop no handler)
builder.Services.AddRefitClient<IAuthenticationService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!))
    .AddHttpMessageHandler<AuthenticationHandler>();



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
    .AddAdditionalAssemblies(typeof(JwtAuthentication.Web.Client._Imports).Assembly);

app.Run();
