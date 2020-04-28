using Core.Models;

namespace Core.DTOs
{
    public class CartItemDto
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }

        public CartItemDto(CartItem cartItem)
        {
            Product = cartItem.Product != null ? new ProductDto(cartItem.Product) : null;
            Quantity = cartItem.Quantity;
        }
    }
}
