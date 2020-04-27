using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Core.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        public CategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Products = category.Products.Select(x => new ProductDto(x));
        }
    }
}
