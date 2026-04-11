using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Data;
using StreetTshirtApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace StreetTshirtApp.Services
{
    public class AuthService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        
        // Agora o compilador encontrará a classe User em StreetTshirtApp.Models
        public User? CurrentUser { get; private set; }
        public event Action? OnChange;

        public bool IsLoggedIn => CurrentUser != null;
        public bool IsAdmin => CurrentUser?.Role == "Admin";

        public AuthService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<bool> Login(string email, string password)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var user = await context.Users
                .Include(u => u.OrderHistory) 
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                CurrentUser = user;
                NotifyStateChanged();
                return true;
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}