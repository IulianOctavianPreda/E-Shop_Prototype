using System;
using System.Collections.Generic;

namespace E_Shop_Mini.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<OrderItems> OrderItems { get; set; }
    }
}
