using StreetTshirtApp.Components;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;
using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Data;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVICE CONFIGURATION ---

// Add services to support Razor Components and Interactive Server-Side rendering
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register AuthService as Scoped. 
// In Blazor Server, Scoped services are tied to the user's circuit (browser tab),
// which is ideal for maintaining authentication state.
builder.Services.AddScoped<AuthService>();

// Register CartService as Scoped to ensure the shopping cart persists 
// as the user navigates through the application during their session.
builder.Services.AddScoped<CartService>();

// Configure Entity Framework Core to use SQLite.
// The connection string points to 'streetwear.db' located in the project root.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=streetwear.db"));

var app = builder.Build();

// --- 2. MIDDLEWARE PIPELINE ---

// Configure error handling and security headers for non-development environments
if (!app.Environment.IsDevelopment())
{
    // Global exception handler to catch unhandled errors
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    // HTTP Strict Transport Security (HSTS) to enforce secure connections
    app.UseHsts();
}

// Intercept specific status codes (like 404) and redirect to a custom 'not-found' page
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

// Enable the application to serve static files from the 'wwwroot' folder.
// This is required to make product images (e.g., /images/tshirt.png) accessible via URL.
app.UseStaticFiles(); 

// Redirect all HTTP requests to HTTPS for data encryption and security
app.UseHttpsRedirection();

// Enable Anti-forgery middleware to protect against CSRF attacks
app.UseAntiforgery();

// Map optimized static assets (a .NET 9 feature for enhanced CSS/JS delivery)
app.MapStaticAssets();

// Map the root 'App' component and specify the render mode for the application
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Start the web application
app.Run();