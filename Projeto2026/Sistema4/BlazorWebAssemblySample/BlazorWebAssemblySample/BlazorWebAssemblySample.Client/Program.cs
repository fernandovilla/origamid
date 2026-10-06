using BlazorWebAssemblySample.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();


builder.Services.AddScoped<HttpClient>(i =>
{
    return new HttpClient { BaseAddress = new Uri("https://localhost:7108") };
});

builder.Services.AddScoped<IClienteService, ClienteService>();

await builder.Build().RunAsync();
