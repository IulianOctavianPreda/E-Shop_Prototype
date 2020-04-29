using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }

        public OrderDto(Order order)
        {
            Id = order.Id;
            OrderDate = order.OrderDate;
            OrderItems = order.OrderItems.Select(x => new OrderItemDto(x)).ToList();
        }
    }
}
