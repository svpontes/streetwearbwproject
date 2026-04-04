namespace StreetTshirtApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public string? AvatarUrl { get; set; }
     
        public string Role { get; set; } = "Customer"; 

        
        public string? Phone { get; set; }      // Adicionado para bater com o erro anterior
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }    // Usando ZipCode para bater com o erro anterior
        public string? Country { get; set; }
        // RELACIONAMENTOS:
        public List<Order> OrderHistory { get; set; } = new();
        
        // REGISTRO:
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}