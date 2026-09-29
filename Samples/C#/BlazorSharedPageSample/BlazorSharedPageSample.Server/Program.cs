using BlazorSharedPageSample.Server.Components;
using BlazorSharedPageSample.Server.Services;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.
    AddRazorComponents()
    .AddInteractiveServerComponents();


// Registra padronização Fluent UI
builder.Services.AddFluentUIComponents(config =>
{
    config.DefaultValues.For<FluentButton>().Set(p => p.Shape, ButtonShape.Circular);
    config.DefaultValues.ForAny<FluentDatePicker<object>>().Set(p => p.Culture, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
});


builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

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

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
