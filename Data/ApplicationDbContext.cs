using Microsoft.EntityFrameworkCore;
using StreetTshirtApp.Models;

namespace StreetTshirtApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NewsletterSubscriber> Subscribers { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}