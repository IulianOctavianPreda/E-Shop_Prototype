using System;
using System.Collections.Generic;

namespace E_Shop_Mini.Models
{
    public class Category 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
