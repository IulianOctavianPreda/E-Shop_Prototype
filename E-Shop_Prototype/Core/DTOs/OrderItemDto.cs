using Core.Models;

namespace Core.DTOs
{
    public class OrderItemDto
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }

        public OrderItemDto(OrderItem orderItem)
        {
            Product = orderItem.Product != null ? new ProductDto(orderItem.Product){ImageData = null} : null;
            Quantity = orderItem.Quantity;
        }
    }
}