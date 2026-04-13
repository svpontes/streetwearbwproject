using System.Text.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetTshirtApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Processing";

        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;

        
        public string SerializedItems { get; set; } = string.Empty;

        // Propriedade para a UI (não salva no banco diretamente pelo EF)
        [NotMapped]
        public List<OrderItem> OrderItems 
        { 
            get 
                {
                    if (string.IsNullOrWhiteSpace(SerializedItems)) return new List<OrderItem>();
                    try 
                    {
                        // O PropertyNameCaseInsensitive é vital se o JSON foi gravado com camelCase
                        return JsonSerializer.Deserialize<List<OrderItem>>(SerializedItems, 
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<OrderItem>();
                    }
                    catch { return new List<OrderItem>(); }
                }
            
            set 
            {
                SerializedItems = JsonSerializer.Serialize(value);
            }
        }
    }
}