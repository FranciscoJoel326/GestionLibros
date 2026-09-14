using GestionLibros.Components;
using GestionLibros.DAL;
using GestionLibros.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var cadenaConexion = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<Contexto>(opciones => opciones.UseSqlite(cadenaConexion));

builder.Services.AddScoped<LibrosService>();

var app = builder.Build();

// Aqui hace la base de datos y la tabla libros de una forma automáticamente si todavía no estan.
using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<Contexto>>();
    await using var contexto = await dbFactory.CreateDbContextAsync();
    await contexto.Database.EnsureCreatedAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
