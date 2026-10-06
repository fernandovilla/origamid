
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Ninegoldy.Components;
using Ninegoldy.Data;
using Npgsql;
using Ninegoldy.Constants;
using Ninegoldy.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ninegoldy.Models.Users;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services
//    .AddRazorComponents()
//    .AddInteractiveServerComponents();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

builder.Services.AddDbContextFactory<ApplicationDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.AddScoped<IAuthService, AuthServices>();


#region Authentication Config

builder.Services.AddCascadingAuthenticationState();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = AuthConstants.AUTH_SCHEMA;
        options.DefaultSignInScheme = AuthConstants.AUTH_SCHEMA_SIGNIN;
        options.DefaultChallengeScheme = AuthConstants.AUTH_SCHEMA_CHALLANGE;
    })
    .AddCookie(AuthConstants.AUTH_SCHEMA, options =>
    {
        options.Cookie.Name = AuthConstants.AUTH_COOKIE;
        options.LoginPath = "/account/login";
        options.LogoutPath = "/account/logout";
        options.AccessDeniedPath = "/account/access-denied";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true;
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
        options.Scope.Add("profile");
        options.Scope.Add("email");
        options.SaveTokens = false; //não é necessário tokens para o Google

    })
    .AddFacebook(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Facebook:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Facebook:ClientSecret"]!;
    });

#endregion




builder.Services.AddMudServices();

//builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseWebAssemblyDebugging();
    //app.UseMigrationsEndPoint();
}


app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();




app.MapPost("/auth/login", async (HttpContext context, IAuthService authService, [FromForm] UserLogin usuarioLogin) =>
{
    var user = await authService.LoginAsync(usuarioLogin);

    if (user == null)
        return Results.Redirect("/account/login?error=invalid_credentials");

    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

    var identity = new ClaimsIdentity(claims, AuthConstants.AUTH_SCHEMA);
    var principal = new ClaimsPrincipal(identity);
    var properties = new AuthenticationProperties
    {
        IsPersistent = usuarioLogin.RememberMe,
        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
    };

    await context.SignInAsync(AuthConstants.AUTH_SCHEMA, principal, properties);

    return Results.Redirect("/");


}).DisableAntiforgery();

app.MapPost("/auth/logout", async (HttpContext http) =>
{
    await http.SignOutAsync(AuthConstants.AUTH_SCHEMA);
    return Results.Redirect("/login");
});

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

//Módulo de Blazor Server e Blazor WebAssembly sendo habilitado para o mesmo projeto, com renderização interativa
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
