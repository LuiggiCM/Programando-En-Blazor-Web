using EjemploInteractivoAutomatico.Client.Pages;
using EjemploInteractivoAutomatico.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents() // En el modo automatico, se agrega el modo interactivo servidor.
    .AddInteractiveWebAssemblyComponents(); // En el modo automatico, se agrega el modo interactivo cliente.

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
    .AddInteractiveServerRenderMode() // En el modo automatico, se agrega el modo interactivo servidor.
    .AddInteractiveWebAssemblyRenderMode() // En el modo automatico, se agrega el modo interactivo cliente.
    .AddAdditionalAssemblies(typeof(EjemploInteractivoAutomatico.Client._Imports).Assembly);

app.Run();
