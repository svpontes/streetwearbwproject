using StreetTshirtApp.Components;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;
using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<AuthService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=streetwear.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
