using System;
using System.IO;
using Core.Models;

namespace Core.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageData { get; set; }
        public int Quantity { get; set; }
        //public string SpecificationFilePath { get; set; }

        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            ImageData = ImagePathToBase64(product.ImagePath);
            Quantity = 0;
        }

        private string ImagePathToBase64(string path)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
        }
    }
}
