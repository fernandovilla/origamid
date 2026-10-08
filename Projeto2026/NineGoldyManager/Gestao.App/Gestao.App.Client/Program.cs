using Blazored.LocalStorage;
using Gestao.App.Client.Libraries.Notifications;
using Gestao.App.Client.Services;
using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

// Scoped = Singleton
builder.Services.AddScoped<HttpClient>(sp =>
{
    return new HttpClient { BaseAddress = new Uri("https://localhost:7049") };
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ISelectNotification, CompanySelectNotification>();


#region Services Dependencies Injection
builder.Services.AddScoped<ICompanyRepository, CompanyService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IAccountRepository, AccountService>();
builder.Services.AddScoped<IFinancialTransactionRepository, FinancialTransactionService>();
#endregion

await builder.Build().RunAsync();
