using StreetTshirtApp.Components;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;
using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração de Serviços
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Correção: AuthService deve ser apenas Scoped ou Singleton conforme sua lógica. 
// Para Blazor Server, Scoped é geralmente melhor para manter o estado por aba.
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CartService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=streetwear.db"));

var app = builder.Build();

// 2. Middleware de Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

// IMPORTANTE: Adicione UseStaticFiles para garantir que /images/ possa ser acessado via URL
app.UseStaticFiles(); 

app.UseHttpsRedirection();
app.UseAntiforgery();

// Mantemos o MapStaticAssets para o CSS/JS otimizado do .NET 9
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();