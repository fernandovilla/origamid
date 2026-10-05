
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Ninegoldy.Components;
using Ninegoldy.Data;
using Npgsql;
using Ninegoldy.Constants;
using Ninegoldy.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
