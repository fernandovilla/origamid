using Blazored.LocalStorage;
using Gestao.App.Client.Libraries.Notifications;
using Gestao.App.Components;
using Gestao.App.Components.Account;
using Gestao.App.Data;
using Gestao.App.Data.Repositories;
using Gestao.App.Libraries.Services;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Morris.Blazor.Validation;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

#region DBContext Dependency Injection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#endregion


#region Configuração de Autenticação

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

//Configuração do Idetity
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

//Configuração de login social
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Google:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Google:ClientSecret")!;
    })
    .AddFacebook(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Facebook:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Facebook:ClientSecret")!;
    })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Microsoft:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Microsoft:ClientSecret")!;
    })
    .AddIdentityCookies();

#endregion


#region Configuração do E-mail Sender
//  GMAIL PARA ENVIO DE CONFIRMAÇÃO DE E-MAIL
//builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddSingleton<SmtpClient>(options =>
{
    var smtp = new SmtpClient();
    smtp.Host = builder.Configuration.GetValue<string>("EmailSender:Host")!;
    smtp.Port = builder.Configuration.GetValue<int>("EmailSender:Port");
    smtp.EnableSsl = builder.Configuration.GetValue<bool>("EmailSender:EnableSsl");
    smtp.Credentials = new NetworkCredential(
        builder.Configuration.GetValue<string>("EmailSender:Credential:Username"),
        builder.Configuration.GetValue<string>("EmailSender:Credential:Password")
    );
    return smtp;
});

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, Gestao.App.Libraries.Mail.EmailSender>();
#endregion


#region Repositories Dependency Injection e outras...

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
builder.Services.AddTransient<IConfigurationManager, ConfigurationManager>(i => builder.Configuration);

#endregion


#region FluentValidation Dependency Injection

// Quando for utilizar em API
//builder.Services.AddScoped<IValidator<Company>, CompanyValidator>();

//https://github.com/mrpmorris/blazor-validation
//https://docs.fluentvalidation.net/en/latest/index.html
builder.Services.AddFormValidation(config => config.AddDataAnnotationsValidation());
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(CompanyValidator).Assembly));
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(AccountValidador).Assembly));
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(CategoryValidator).Assembly));
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(FinancialTransactionValidator).Assembly));

#endregion


#region Anothers Dependency Injection

builder.Services.AddSingleton<ICepServices, CepServices>();
builder.Services.AddScoped<ICompanySelectNotification, CompanySelectNotification>();

#endregion


builder.Services.AddBlazoredLocalStorage();


builder.Services
    .AddControllers();  //Habilita o uso de controllers

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();  //Habilita redirecionamento de HTTP para HTTPS (se permitido)

app.UseStaticFiles();       //libera a pasta wwwroot para acesso público
app.UseAntiforgery();      //habilita a proteção contra CSRF

app.MapStaticAssets();

//Módulo de Blazor Server e Blazor WebAssembly sendo habilitado para o mesmo projeto, com renderização interativa
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Gestao.App.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

#region Minimal APIs Endpoints

//Habilita o uso de Controllers para APIs REST
app.MapControllers(); 

// Aqui tb poderia ser mapeado os métodos para cada endpoint
//app.MapGet("/api/health", () => {
//    ...
//))
    
#endregion

app.Run();
