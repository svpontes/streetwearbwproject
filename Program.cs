using StreetTshirtApp.Components;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTRO DE SERVIÇOS (DI) ---
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registramos os serviços necessários para a BluntWear
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<AuthService>();

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

// --- 3. DECLARAÇÕES DE NAMESPACE E CLASSES ---
namespace StreetTshirtApp.Services
{
    public class AuthService
    {
        public User? CurrentUser { get; private set; }
        public event Action? OnChange;

        public void Login(string email, string password)
        {
            // Simulação de banco de dados para a BluntWear
            if (email == "user@blunt.com" && password == "123")
            {
                CurrentUser = new User { Id = 1, Name = "DRIP MASTER", Email = email };
                NotifyStateChanged();
            }
        }

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}