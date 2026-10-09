using EjemploWebAssemblyInteractivo.Client.Pages;
using EjemploWebAssemblyInteractivo.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents(); // Con esto se da la capacidad a las páginas para funcionar con el modo interactivo del lado de cliente.

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
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(EjemploWebAssemblyInteractivo.Client._Imports).Assembly); // Con esto se da la capacidad a las páginas para funcionar con el modo interactivo del lado de cliente. Hace referencia al proyecto `Client`.

app.Run();
