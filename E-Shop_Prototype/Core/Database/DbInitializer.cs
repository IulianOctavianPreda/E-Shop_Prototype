using System;
using System.Linq;
using Core.Models;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Database
{
    public static class DbInitializer
    {
        private static string EncryptPassword(string password)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(password);
            var hash = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(hash);
        }
        public static void Initialize(SqlServerContext context)
        {
            // Look for any students.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            context.Database.Migrate();

            var users = new User[]
            {
            new User{Id = Guid.NewGuid(), UserName = "admin", Password = EncryptPassword("toor")},
            };
            foreach (var u in users)
            {
                context.User.Add(u);
            }

            context.SaveChanges();

            var categories = new Category[]
            {
            new Category{Id = Guid.NewGuid(), Name = "Books"},
            new Category{Id = Guid.NewGuid(), Name = "Movies"},
            new Category{Id = Guid.NewGuid(), Name = "Technology"},
            };
            foreach (var c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{Id = Guid.NewGuid(),  Name = "Lord of the Rings", ImagePath = "./Assets/Images/Lotr.jpg", SpecificationFilePath = "./Assets/Specifications/Lotr.pdf", Description = "Lord of the rings book, just now in the shop. best seller", Price = 20},

            new Product{Id = Guid.NewGuid(),  Name = "Parasite", ImagePath = "./Assets/Images/parasite.jpg", SpecificationFilePath = "./Assets/Specifications/parasite.pdf", Description = "Oscar winning movie", Price = 55},

            new Product{Id = Guid.NewGuid(),  Name = "Ryzen 3900X", ImagePath = "./Assets/Images/ryzen3900.jpg", SpecificationFilePath = "./Assets/Specifications/ryzen3900.pdf", Description = "AMD CPU for AM4 socket", Price = 4000},

            new Product{Id = Guid.NewGuid(),  Name = "Ryzen 3700X", ImagePath = "./Assets/Images/ryzen3700.jpg", SpecificationFilePath = "./Assets/Specifications/ryzen3700.pdf", Description = "AMD CPU for AM4 socket", Price = 3000},

            };

            foreach (var e in products)
            {
                context.Product.Add(e);
            }
            context.SaveChanges();
        }
    }
}
