using StreetTshirtApp.Components;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;
using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Data;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTRO DE SERVIÇOS (DI) ---
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registramos os serviços necessários para a BluntWear
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=streetwear.db"));

var app = builder.Build();

// --- 2. CONFIGURAÇÃO DO PIPELINE (MIDDLEWARES) ---
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

// IMPORTANTE: O mapeamento deve vir ANTES do app.Run()
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// O Run deve ser a ÚLTIMA instrução de nível superior
app.Run();
