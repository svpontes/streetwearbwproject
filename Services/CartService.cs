using System;
using System.Collections.Generic;
using System.Linq;
using StreetTshirtApp.Models;

namespace StreetTshirtApp.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems = new();

        public event Action? OnChange;

        public List<CartItem> CartItems => _cartItems;

        public int TotalItems => _cartItems.Sum(i => i.Quantity);

        public decimal TotalPrice => _cartItems.Sum(i => i.Product.Price * i.Quantity);

        public void AddToCart(Product product, string size, int quantity)
        {
            if (product == null || quantity <= 0)
                return;

            var existingItem = _cartItems.FirstOrDefault(i =>
                i.Product.Id == product.Id && i.Size == size);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem
                {
                    Product = product,
                    Size = size,
                    Quantity = quantity
                });
            }

            NotifyStateChanged();
        }

        public void UpdateQuantity(int productId, string size, int change)
        {
            var item = _cartItems.FirstOrDefault(i =>
                i.Product.Id == productId && i.Size == size);

            if (item == null)
                return;

            item.Quantity += change;

            if (item.Quantity <= 0)
            {
                _cartItems.Remove(item);
            }

            NotifyStateChanged();
        }

        public void RemoveFromCart(int productId, string size)
        {
            var item = _cartItems.FirstOrDefault(i =>
                i.Product.Id == productId && i.Size == size);

            if (item == null)
                return;

            _cartItems.Remove(item);
            NotifyStateChanged();
        }

        public void ClearCart()
        {
            _cartItems.Clear();
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }

    public class CartItem
    {
        public Product Product { get; set; } = new();
        public string Size { get; set; } = "M";
        public int Quantity { get; set; }
    }
}