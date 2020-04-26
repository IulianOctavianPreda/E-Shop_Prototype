using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Cart Cart { get; set; }
    }
}
