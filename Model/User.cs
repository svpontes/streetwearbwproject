namespace StreetTshirtApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public string? AvatarUrl { get; set; }
        
        // ESSENCIAL PARA O ADMIN LEDGER:
        // Valores comuns: "Admin" ou "Customer"
        public string Role { get; set; } = "Customer"; 

        // CAMPOS PARA O CHECKOUT AUTOMÁTICO:
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public List<Order> OrderHistory { get; set; } = new();
        
        // Para fins jurídicos: saber quando o usuário se cadastrou
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}