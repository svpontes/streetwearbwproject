using System.ComponentModel.DataAnnotations.Schema;

namespace StreetTshirtApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        [NotMapped]
        public List<string> AvailableSizes { get; set; } = new();

        [NotMapped]
        public List<string> SecondaryImageUrls { get; set; } = new();
    }
}