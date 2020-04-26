using System;
using System.Collections.Generic;


namespace Core.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public string SpecificationFilePath { get; set; }


        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<OrderItems> OrderItems { get; set; }
    }
}
