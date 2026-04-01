using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Models; 

namespace StreetTshirtApp.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        // Aproveite e já adicione a tabela de Usuários para o Login funcionar
        public DbSet<User> Users { get; set; }
    }
}