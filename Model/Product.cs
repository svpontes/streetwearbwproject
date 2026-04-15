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

        public string SecondaryImageUrlsRaw { get; set; } = string.Empty;

        [NotMapped]
        public List<string> AvailableSizes { get; set; } = new();

        [NotMapped]
        public List<string> SecondaryImageUrls
        {
            get => string.IsNullOrWhiteSpace(SecondaryImageUrlsRaw)
                ? new List<string>()
                : SecondaryImageUrlsRaw
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList();

            set => SecondaryImageUrlsRaw = value == null || !value.Any()
                ? string.Empty
                : string.Join("\n", value);
        }
    }
}