using Xunit;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;
using System.Linq;

namespace StreetTshirtApp.Tests
{
    public class CartServiceTests
    {
        private readonly CartService _cartService;
        private readonly Product _testProduct;

        public CartServiceTests()
        {
            _cartService = new CartService();
            _testProduct = new Product 
            { 
                Id = 1, 
                Name = "Classic Skull", 
                Price = 25.00m,
                ImageUrl = "/images/classic-skull.png" 
            };
        }

        // Atende ao REQ-CART-001 (Add products to the cart)
        [Fact]
        public void TC_CART_001_AddProductToCartSuccessfully()
        {
            _cartService.AddToCart(_testProduct, "L", 1);

            Assert.Single(_cartService.CartItems);
            Assert.Equal("Classic Skull", _cartService.CartItems.First().Product.Name);
        }

        [Fact]
        public void TC_CART_003_AddSameProductTwice()
        {
            _cartService.AddToCart(_testProduct, "L", 1);
            _cartService.AddToCart(_testProduct, "L", 1);

            // Verifica se a lógica do seu CartService soma quantidades ou duplica linhas
            // Ajuste o Assert conforme a regra de negócio que definiu no Squash
            var item = _cartService.CartItems.First();
            Assert.Equal(2, item.Quantity); 
        }

        // Atende ao REQ-CART-002 (Remove products from the cart)
        [Fact]
        public void TC_CART_005_RemoveOneProductFromCart()
        {
            _cartService.AddToCart(_testProduct, "L", 1);
            
            // Assume-se que o método RemoveFromCart recebe Id e Size conforme sua lógica
            _cartService.RemoveFromCart(_testProduct.Id, "L");

            Assert.Empty(_cartService.CartItems);
        }

        [Fact]
        public void TC_CART_007_RemoveAllProductsFromCart()
        {
            _cartService.AddToCart(_testProduct, "L", 1);
            var product2 = new Product { Id = 2, Name = "Sunset", Price = 30.00m };
            _cartService.AddToCart(product2, "M", 1);

            _cartService.ClearCart(); // Certifique-se que este método existe no CartService.cs

            Assert.Empty(_cartService.CartItems);
        }
    }
}