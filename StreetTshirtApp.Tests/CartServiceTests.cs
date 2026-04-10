using Xunit;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;
using System.Linq;

namespace StreetTshirtApp.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public void AddToCart_ShouldAddItemToList()
        {
            // Arrange
            var cartService = new CartService();
            var product = new Product 
            { 
                Id = 1, 
                Name = "Classic Skull", 
                Price = 25.00m,
                ImageUrl = "/images/classic-skull.png" 
            };
            
            // Act
            cartService.AddToCart(product, "L", 1);

            // Assert
            Assert.Single(cartService.CartItems);
            var itemInCart = cartService.CartItems.First();
            Assert.Equal("Classic Skull", itemInCart.Product.Name);
            Assert.Equal("L", itemInCart.Size);
        }
    }
}