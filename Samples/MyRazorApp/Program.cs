var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseStaticFiles();       //arquivos de wwwroot

app.UseRouting();           //url custmizadas
app.MapRazorPages();

app.Run();



//https://youtu.be/UNMfTGiAR2c?t=6604