namespace StreetTshirtApp.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int Rating { get; set; } // 1 a 5
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}