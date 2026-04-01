using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Data;
using StreetTshirtApp.Models;

namespace StreetTshirtApp.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        public User? CurrentUser { get; private set; }
        
        // ADICIONE ESTA LINHA:
        public event Action? OnChange;

        public AuthService(ApplicationDbContext context) => _context = context;

        public async Task<bool> Login(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                CurrentUser = user;
                NotifyStateChanged(); // NOTIFICA O MENU
                return true;
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged(); // NOTIFICA O MENU
        }

        // ADICIONE ESTE MÉTODO:
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}